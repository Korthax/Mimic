using System;
using System.Text;

namespace Mimic.Core.Services.Factories
{
    public interface IValueFactory
    {
        int Int(int min, int max);
        double Double(int min, int max);
        string String(int length);
        char Char();
        byte[] Bytes(int bufferSize);
    }

    internal class RandomValueFactory : IValueFactory
    {
        private static readonly char[] Characters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();
        private static readonly Random Random = new Random();

        public int Int(int min, int max)
        {
            return Random.Next(min, max + 1);
        }

        public double Double(int min, int max)
        {
            return Random.Next(min, max) + Random.NextDouble();
        }

        public string String(int length = 15)
        {
            var builder = new StringBuilder();
            for (var i = 0; i < length; i++)
                builder.Append(Characters[Random.Next(Characters.Length)]);
            return builder.ToString().ToLower();
        }

        public char Char()
        {
            return Characters[Random.Next(Characters.Length)];
        }

        public byte[] Bytes(int bufferSize)
        {
            var buffer = new byte[bufferSize];
            Random.NextBytes(buffer);
            return buffer;
        }
    }
}