﻿using System;

public struct EncLong
{
    /// A struct for storing a 64-bit integer while efficiently keeping it encrypted in the memory.
    /// In the memory it is saved as a floating-point number that is affected by random values. { encryptionKey1 & encryptionKey2 }
    /// Every time the value changes, the encryption keys change too. And it works exactly as an long.
    ///
    /// WIKI & INFO: https://github.com/JosepeDev/VarEnc

    #region Variables - Properties - Methods - Constructors

    // The encryption values
    private readonly decimal encryptionKey1;
    private readonly decimal encryptionKey2;

    // The encrypted value stored in memory
    private readonly decimal encryptedValue;

    // The decrypted value
    private long Value
    {
        get => (long)Decrypt();
    }

    public long MaxValue { get => Int64.MaxValue; }
    public long MinValue { get => Int64.MinValue; }

    private EncLong(decimal value)
    {
        encryptionKey1 = (decimal)(random.NextDouble() * 0.001);
        encryptionKey2 = (decimal)(random.NextDouble() * 100);
        encryptedValue = Encrypt(value, encryptionKey1, encryptionKey2);
    }

    // Encryption Key Generator
    static private Random random = new Random();

    // Takes a given value and returns it encrypted
    private static decimal Encrypt(decimal value, decimal k1, decimal k2) => (value + k1) * k2;

    // Takes an encrypted value and returns it decrypted
    private decimal Decrypt() => ((encryptedValue / encryptionKey2) - encryptionKey1) + 0.5m;

    // Int64 methods
    public int CompareTo(object value) => Value.CompareTo(value);
    public int CompareTo(long value) => Value.CompareTo(value);
    public bool Equals(long obj) => Value.Equals(obj);
    public override bool Equals(object obj) => Value.Equals(obj);
    public override int GetHashCode() => Value.GetHashCode();
    public TypeCode GetTypeCode() => Value.GetTypeCode();
    public override string ToString() => Value.ToString();
    public string ToString(IFormatProvider provider) => Value.ToString(provider);
    public string ToString(string format) => Value.ToString(format);
    public string ToString(string format, IFormatProvider provider) => Value.ToString(format, provider);

    #endregion

    #region Operators Overloading

    /// & | ^
    public static EncLong operator &(EncLong elong1, EncLong elong2) => new EncLong(elong1.Value & elong2.Value);
    public static EncLong operator |(EncLong elong1, EncLong elong2) => new EncLong(elong1.Value | elong2.Value);
    public static EncLong operator ^(EncLong elong1, EncLong elong2) => new EncLong(elong1.Value ^ elong2.Value);

    public static long operator &(EncLong elong1, long elong2) => elong1.Value & elong2;
    public static long operator |(EncLong elong1, long elong2) => elong1.Value | elong2;
    public static long operator ^(EncLong elong1, long elong2) => elong1.Value ^ elong2;

    /// + - * / %
    public static EncLong operator +(EncLong elong1, EncLong elong2) => new EncLong(elong1.Value + elong2.Value);
    public static EncLong operator -(EncLong elong1, EncLong elong2) => new EncLong(elong1.Value - elong2.Value);
    public static EncLong operator *(EncLong elong1, EncLong elong2) => new EncLong(elong1.Value * elong2.Value);
    public static EncLong operator /(EncLong elong1, EncLong elong2) => new EncLong(elong1.Value / elong2.Value);
    public static EncLong operator %(EncLong elong1, EncLong elong2) => new EncLong(elong1.Value % elong2.Value);

    public static long operator +(EncLong elong1, long elong2) => elong1.Value + elong2;
    public static long operator -(EncLong elong1, long elong2) => elong1.Value - elong2;
    public static long operator *(EncLong elong1, long elong2) => elong1.Value * elong2;
    public static long operator /(EncLong elong1, long elong2) => elong1.Value / elong2;
    public static long operator %(EncLong elong1, long elong2) => elong1.Value % elong2;

    public static long operator +(EncLong elong1, int elong2) => elong1.Value + elong2;
    public static long operator -(EncLong elong1, int elong2) => elong1.Value - elong2;
    public static long operator *(EncLong elong1, int elong2) => elong1.Value * elong2;
    public static long operator /(EncLong elong1, int elong2) => elong1.Value / elong2;
    public static long operator %(EncLong elong1, int elong2) => elong1.Value % elong2;

    public static long operator +(EncLong elong1, short elong2) => elong1.Value + elong2;
    public static long operator -(EncLong elong1, short elong2) => elong1.Value - elong2;
    public static long operator *(EncLong elong1, short elong2) => elong1.Value * elong2;
    public static long operator /(EncLong elong1, short elong2) => elong1.Value / elong2;
    public static long operator %(EncLong elong1, short elong2) => elong1.Value % elong2;

    public static long operator +(EncLong elong1, ushort elong2) => elong1.Value + elong2;
    public static long operator -(EncLong elong1, ushort elong2) => elong1.Value - elong2;
    public static long operator *(EncLong elong1, ushort elong2) => elong1.Value * elong2;
    public static long operator /(EncLong elong1, ushort elong2) => elong1.Value / elong2;
    public static long operator %(EncLong elong1, ushort elong2) => elong1.Value % elong2;

    public static long operator +(EncLong elong1, uint elong2) => elong1.Value + elong2;
    public static long operator -(EncLong elong1, uint elong2) => elong1.Value - elong2;
    public static long operator *(EncLong elong1, uint elong2) => elong1.Value * elong2;
    public static long operator /(EncLong elong1, uint elong2) => elong1.Value / elong2;
    public static long operator %(EncLong elong1, uint elong2) => elong1.Value % elong2;

    public static long operator +(EncLong elong1, byte elong2) => elong1.Value + elong2;
    public static long operator -(EncLong elong1, byte elong2) => elong1.Value - elong2;
    public static long operator *(EncLong elong1, byte elong2) => elong1.Value * elong2;
    public static long operator /(EncLong elong1, byte elong2) => elong1.Value / elong2;
    public static long operator %(EncLong elong1, byte elong2) => elong1.Value % elong2;

    public static long operator +(EncLong elong1, sbyte elong2) => elong1.Value + elong2;
    public static long operator -(EncLong elong1, sbyte elong2) => elong1.Value - elong2;
    public static long operator *(EncLong elong1, sbyte elong2) => elong1.Value * elong2;
    public static long operator /(EncLong elong1, sbyte elong2) => elong1.Value / elong2;
    public static long operator %(EncLong elong1, sbyte elong2) => elong1.Value % elong2;

    /// == != < >
    /// 

    public static bool operator ==(EncLong elong1, byte elong2) => elong1.Value == elong2;
    public static bool operator !=(EncLong elong1, byte elong2) => elong1.Value != elong2;
    public static bool operator >(EncLong elong1, byte elong2) => elong1.Value > elong2;
    public static bool operator <(EncLong elong1, byte elong2) => elong1.Value < elong2;

    public static bool operator ==(EncLong elong1, sbyte elong2) => elong1.Value == elong2;
    public static bool operator !=(EncLong elong1, sbyte elong2) => elong1.Value != elong2;
    public static bool operator >(EncLong elong1, sbyte elong2) => elong1.Value > elong2;
    public static bool operator <(EncLong elong1, sbyte elong2) => elong1.Value < elong2;

    public static bool operator ==(EncLong elong1, short elong2) => elong1.Value == elong2;
    public static bool operator !=(EncLong elong1, short elong2) => elong1.Value != elong2;
    public static bool operator >(EncLong elong1, short elong2) => elong1.Value > elong2;
    public static bool operator <(EncLong elong1, short elong2) => elong1.Value < elong2;

    public static bool operator ==(EncLong elong1, ushort elong2) => elong1.Value == elong2;
    public static bool operator !=(EncLong elong1, ushort elong2) => elong1.Value != elong2;
    public static bool operator >(EncLong elong1, ushort elong2) => elong1.Value > elong2;
    public static bool operator <(EncLong elong1, ushort elong2) => elong1.Value < elong2;

    public static bool operator ==(EncLong elong1, uint elong2) => elong1.Value == elong2;
    public static bool operator !=(EncLong elong1, uint elong2) => elong1.Value != elong2;
    public static bool operator >(EncLong elong1, uint elong2) => elong1.Value > elong2;
    public static bool operator <(EncLong elong1, uint elong2) => elong1.Value < elong2;

    public static bool operator ==(EncLong elong1, int elong2) => elong1.Value == elong2;
    public static bool operator !=(EncLong elong1, int elong2) => elong1.Value != elong2;
    public static bool operator >(EncLong elong1, int elong2) => elong1.Value > elong2;
    public static bool operator <(EncLong elong1, int elong2) => elong1.Value < elong2;

    public static bool operator ==(EncLong elong1, long elong2) => elong1.Value == elong2;
    public static bool operator !=(EncLong elong1, long elong2) => elong1.Value != elong2;
    public static bool operator >(EncLong elong1, long elong2) => elong1.Value > elong2;
    public static bool operator <(EncLong elong1, long elong2) => elong1.Value < elong2;

    public static bool operator ==(EncLong elong1, EncLong elong2) => elong1.Value == elong2.Value;
    public static bool operator !=(EncLong elong1, EncLong elong2) => elong1.Value != elong2.Value;
    public static bool operator <(EncLong elong1, EncLong elong2) => elong1.Value < elong2.Value;
    public static bool operator >(EncLong elong1, EncLong elong2) => elong1.Value > elong2.Value;

    /// assign
    public static implicit operator EncLong(long value) => new EncLong(value);
    public static explicit operator ulong(EncLong elong1) => (ulong)elong1.Value;
    public static implicit operator long(EncLong elong1) => elong1.Value;
    public static explicit operator uint(EncLong elong1) => (uint)elong1.Value;
    public static explicit operator int(EncLong elong1) => (int)elong1.Value;
    public static explicit operator ushort(EncLong elong1) => (ushort)elong1.Value;
    public static explicit operator short(EncLong elong1) => (short)elong1.Value;
    public static explicit operator byte(EncLong elong1) => (byte)elong1.Value;
    public static explicit operator sbyte(EncLong elong1) => (sbyte)elong1.Value;
    public static implicit operator decimal(EncLong elong1) => elong1.Value;
    public static implicit operator double(EncLong elong1) => elong1.Value;
    public static implicit operator float(EncLong elong1) => elong1.Value;

    #endregion
}