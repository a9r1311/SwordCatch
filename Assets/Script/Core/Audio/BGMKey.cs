public readonly struct BGMKey : System.IEquatable<BGMKey>    //  BGMKey\‘¢‘Ì
{
    private readonly int _value;    //  Key’l

    public BGMKey(int value)    //  Key’lİ’èAPI
    {
        _value = value;
    }

    public override int GetHashCode() => _value;
    public bool Equals(BGMKey other) => _value == other._value;
    public override bool Equals(object obj) => obj is BGMKey other && Equals(other);
    
    public static implicit operator int(BGMKey key) => key._value;    //  BGMkeyŒ^‚ğintŒ^‚ÉˆÃ–Ù•ÏŠ·‚·‚é‰‰Zq
}
