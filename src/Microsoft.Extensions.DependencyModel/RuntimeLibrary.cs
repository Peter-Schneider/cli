// Copyright (c) .NET Foundation and contributors. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using System.Collections.Generic;
using System.Linq;

namespace Microsoft.Extensions.DependencyModel
{
    public class RuntimeLibrary : Library
    {
        public RuntimeLibrary(
            string type,
            string name,
            string version,
            string hash,
            RuntimeAssetCollection<RuntimeAssembly> assemblies,
            RuntimeAssetCollection<string> nativeLibraries,
            IEnumerable<ResourceAssembly> resourceAssemblies,
            IEnumerable<Dependency> dependencies,
            bool serviceable)
            : base(type, name, version, hash, dependencies, serviceable)
        {
            if (assemblies == null)
            {
                throw new ArgumentNullException(nameof(assemblies));
            }
            if (nativeLibraries == null)
            {
                throw new ArgumentNullException(nameof(nativeLibraries));
            }
            if (resourceAssemblies == null)
            {
                throw new ArgumentNullException(nameof(resourceAssemblies));
            }
            Assemblies = assemblies;
            ResourceAssemblies = resourceAssemblies.ToArray();
            NativeLibraries = nativeLibraries;
        }

        public RuntimeAssetCollection<RuntimeAssembly> Assemblies { get; }

        public RuntimeAssetCollection<string> NativeLibraries { get; }

        public IReadOnlyList<ResourceAssembly> ResourceAssemblies { get; }
    }
}