// Copyright (c) .NET Foundation and contributors. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;

namespace Microsoft.Extensions.DependencyModel
{
    public class RuntimeAsset
    {
        private const string NativeImageSufix = ".ni";

        public RuntimeAsset(string name, string path)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentException(nameof(name));
            }
            if (string.IsNullOrEmpty(path))
            {
                throw new ArgumentException(nameof(path));
            }
            Name = name;
            Path = path;
        }

        public string Name { get; }

        public string Path { get; }

        public static RuntimeAsset Create(string path)
        {
            var name = System.IO.Path.GetFileNameWithoutExtension(path);
            if (name == null)
            {
                throw new ArgumentException($"Provided path has empty file name '{path}'", nameof(path));
            }

            if (name.EndsWith(NativeImageSufix))
            {
                name = name.Substring(0, name.Length - NativeImageSufix.Length);
            }
            return new RuntimeAsset(name, path);
        }
    }
}