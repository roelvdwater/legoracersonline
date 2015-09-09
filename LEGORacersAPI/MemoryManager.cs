using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;

namespace LEGORacersAPI
{
    public class MemoryManager
    {
        [DllImport("kernel32")]
        private static extern IntPtr OpenProcess(uint dwDesiredAccess, bool bInheritHandle, int dwProcessId);
        [DllImport("kernel32")]
        private static extern bool ReadProcessMemory(IntPtr hProcess, IntPtr address, byte[] buffer, uint size, out int bytesread);
        [DllImport("kernel32")]
        private static extern bool WriteProcessMemory(IntPtr hProcess, uint address, byte[] buffer, uint size, out int byteswritten);
        [DllImport("kernel32")]
        private static extern uint VirtualAllocEx(IntPtr hProcess, uint dwAddress, uint nSize, uint dwAllocationType, uint dwProtect);
        [DllImport("kernel32")]
        private static extern IntPtr CreateRemoteThread(IntPtr hProcess, IntPtr lpThreadAttributes, uint dwStackSize, IntPtr lpStartAddress, IntPtr lpParameter, uint dwCreationFlags, out IntPtr dwThreadId);
        
        public IntPtr OpenedProcess { get; private set; }
        public uint NewMemory { get; set; }

        public Process Process { get; private set; }

        public MemoryManager(Process process)
        {
            this.Process = process;
            OpenedProcess = OpenProcess(0x1F0FFF, false, process.Id);
            NewMemory = AllocateMemory(1024);
        }

        private int GetNumberOfPlayers()
        {
            return ReadInt(ReadInt(0x004C4914) + 0x598);
        }

        public void Execute(uint address)
        {
            IntPtr threadid;
            CreateRemoteThread(OpenedProcess, IntPtr.Zero, 0, (IntPtr)address, IntPtr.Zero, 0, out threadid);
        }

        private uint AllocateMemory(uint size)
        {
            return VirtualAllocEx(OpenedProcess, 0, size, 0x1000, 0x40);
        }

        public int ReadInt(int address)
        {
            return BitConverter.ToInt32(ReadBytes(address, 4), 0);
        }

        public float ReadFloat(int address)
        {
            return BitConverter.ToSingle(ReadBytes(address, 4), 0);
        }

        public bool WriteInt(int address, int value)
        {
            return WriteBytes(address, BitConverter.GetBytes(value));
        }

        public bool WriteFloat(int address, float value)
        {
            return WriteBytes(address, BitConverter.GetBytes(value));
        }
        public short ReadShort(int address)
        {
            return BitConverter.ToInt16(ReadBytes(address, 4), 0);
        }

        public byte[] GetStringBytes(string input)
        {
            List<byte> output = new List<byte>();
            foreach (char c in input)
            {
                output.Add(Convert.ToByte(c));
                output.Add(0x00);
            }
            output.Add(0x00);
            return output.ToArray();
        }

        public int CalculatePointer(int address, params int[] offsets)
        {
            address = ReadInt(address);
            
            for (int i = 0; i < offsets.Length - 1; i++)
            {
                address = ReadInt(address + offsets[i]);
            }

            return address + offsets.LastOrDefault();
        }

        public byte ReadByte(int address)
        {
            return ReadBytes(address, 1)[0];
        }

        public byte[] ReadBytes(int address, uint count)
        {
            byte[] buffer = new byte[count];
            int bytesread;

            ReadProcessMemory(OpenedProcess, (IntPtr)address, buffer, count, out bytesread);

            return buffer;
        }

        public bool WriteBytes(int address, byte[] bytesToWrite)
        {
            int bytesWritten;

            return WriteProcessMemory(OpenedProcess, (uint)address, bytesToWrite, (uint)bytesToWrite.Length, out bytesWritten);
        }

        public bool WriteByte(int address, byte byteToWrite)
        {
            return WriteBytes(address, new byte[] { byteToWrite });
        }
    }
}
