// Copyright (c) .NET Foundation and contributors. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System.Linq;
using System.Collections.Generic;

namespace Microsoft.DotNet.ProjectModel.Compilation
{
    public class RuntimeAssetGroup
    {
        public RuntimeAssetGroup(string runtime,
            IEnumerable<LibraryAsset> assets)
        {
            Runtime = runtime;
            Assets = assets.ToArray();
        }

        public string Runtime { get; }

        /// <summary>
        /// Gets a list of assets provided in this runtime group
        /// </summary>
        public IReadOnlyList<LibraryAsset> Assets { get; }
    }
}