using System.Text.Json;

namespace AdventOfCode.Leaderboard.Json
{
    internal interface IElementJson<T>
    {
        static abstract T Deserialize(JsonElement json);
    }
}
