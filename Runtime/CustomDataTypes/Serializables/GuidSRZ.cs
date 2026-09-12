using System;
using UnityEngine;

namespace UUP.CustomDataTypes.Serializables
{
    /// <summary>
    /// Serializable Guid
    /// </summary>
    [Serializable]
    public struct GuidSRZ : IEquatable<GuidSRZ>, IConvertible<Guid>
    {
        [SerializeField, HideInInspector] public uint Part1;
        [SerializeField, HideInInspector] public uint Part2;
        [SerializeField, HideInInspector] public uint Part3;
        [SerializeField, HideInInspector] public uint Part4;

        public static GuidSRZ Empty => new GuidSRZ(0, 0, 0, 0);

        public GuidSRZ(uint part1, uint part2, uint part3, uint part4)
        {
            Part1 = part1;
            Part2 = part2;
            Part3 = part3;
            Part4 = part4;
        }

        public GuidSRZ(Guid data)
        {
            byte[] bytes = data.ToByteArray();
            Part1 = BitConverter.ToUInt32(bytes, 0);
            Part2 = BitConverter.ToUInt32(bytes, 4);
            Part3 = BitConverter.ToUInt32(bytes, 8);
            Part4 = BitConverter.ToUInt32(bytes, 12);
        }

        public static GuidSRZ NewGuid() => Guid.NewGuid().ToSerializableGuid();

        public static GuidSRZ FromHexString(string hexString)
        {
            if(hexString.Length != 32)
            {
                throw new FormatException("Invalid hex string length");
            }

            return new GuidSRZ(
                Convert.ToUInt32(hexString.Substring(0, 8), 16),
                Convert.ToUInt32(hexString.Substring(8, 8), 16),
                Convert.ToUInt32(hexString.Substring(16, 8), 16),
                Convert.ToUInt32(hexString.Substring(24, 8), 16)
            );
        }

        public string ToHexString()
        {
            return Part1.ToString("X8") + Part2.ToString("X8") + Part3.ToString("X8") + Part4.ToString("X8");
        }

        public Guid ToGuid()
        {
            byte[] bytes = new byte[16];
            BitConverter.GetBytes(Part1).CopyTo(bytes, 0);
            BitConverter.GetBytes(Part2).CopyTo(bytes, 4);
            BitConverter.GetBytes(Part3).CopyTo(bytes, 8);
            BitConverter.GetBytes(Part4).CopyTo(bytes, 12);
            return new Guid(bytes);
        }

        public static implicit operator Guid(GuidSRZ data) => data.ToGuid();
        public static implicit operator GuidSRZ(Guid data) => new GuidSRZ(data);

        public override bool Equals(object obj)
        {
            return obj is GuidSRZ other && this.Equals(other);
        }

        public bool Equals(GuidSRZ other)
        {
            return Part1 == other.Part1 && Part2 == other.Part2 && Part3 == other.Part3 && Part4 == other.Part4;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Part1, Part2, Part3, Part4);
        }

        public void Set(Guid data)
        {
            byte[] bytes = data.ToByteArray();
            Part1 = BitConverter.ToUInt32(bytes, 0);
            Part2 = BitConverter.ToUInt32(bytes, 4);
            Part3 = BitConverter.ToUInt32(bytes, 8);
            Part4 = BitConverter.ToUInt32(bytes, 12);
        }

        public Guid Get()
        {
            return ToGuid();
        }

        public static bool operator ==(GuidSRZ left, GuidSRZ right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(GuidSRZ left, GuidSRZ right)
        {
            return !left.Equals(right);
        }
    }
}
