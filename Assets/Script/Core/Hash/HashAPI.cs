public static class HashAPI    //  ハッシュAPIクラス
{
    public static int StableHash(string text)    //  不変ハッシュ値を生成
    {
        unchecked
        {
            const int fnvPrime = 16777619;
            int hash = (int)2166136261;

            for (int i = 0; i < text.Length; i++)
            {
                hash ^= text[i];
                hash *= fnvPrime;
            }

            return hash;
        }
    }
}
