﻿namespace PageReplacementAlgorithms
{
    public static class IdGenerator
    {
        private static int _lastId;
        public static int GetNext() => ++_lastId;
    }
}