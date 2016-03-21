using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Microsoft.Extensions.DependencyModel
{
    public class RuntimeAssetCollection<T>
    {
        private readonly IReadOnlyDictionary<string, IReadOnlyList<T>> _runtimeGroups;

        public IEnumerable<KeyValuePair<string, IReadOnlyList<T>>> RuntimeGroups => _runtimeGroups.Where(p => !string.IsNullOrEmpty(p.Key));

        public RuntimeAssetCollection(IDictionary<string, IReadOnlyList<T>> runtimeGroups)
        {
            _runtimeGroups = new ReadOnlyDictionary<string, IReadOnlyList<T>>(runtimeGroups);
        }

        public IEnumerable<T> GetRuntimeAgnosticAssets() => GetAssetsForRuntimeCore(string.Empty);

        public IEnumerable<T> GetAssetsForRuntime(string runtimeIdentifier)
        {
            // Don't allow empty strings here, we don't want to leak the fact that the empty string is used for RIDless assets
            // because it is gross and depressing ;)
            if(string.IsNullOrEmpty(runtimeIdentifier))
            {
                throw new ArgumentNullException(nameof(runtimeIdentifier));
            }
            return GetAssetsForRuntimeCore(runtimeIdentifier);
        }

        private IEnumerable<T> GetAssetsForRuntimeCore(string runtimeIdentifier)
        {
            IReadOnlyList<T> result;
            if(_runtimeGroups.TryGetValue(runtimeIdentifier, out result))
            {
                return result;
            }
            return Enumerable.Empty<T>();
        }
    }
}
