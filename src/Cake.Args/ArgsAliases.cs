// Copyright 2021 C. Augusto Proiete & Contributors
//
// Licensed under the MIT (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//     https://opensource.org/licenses/MIT
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

using System;
using Cake.Common;
using Cake.Core;
using Cake.Core.Annotations;

namespace Cake.Args
{
    /// <summary>
    /// Args aliases
    /// </summary>
    [CakeAliasCategory("Args")]
    [CakeNamespaceImport("Cake.Args")]
    public static class ArgsAliases
    {
        /// <summary>
        /// Gets an argument value or default(T) if the argument is missing.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="name">The argument name.</param>
        /// <returns>The value of the argument or the default value of the type of the argument.</returns>
        /// <example>
        /// <code>
        /// <![CDATA[
        /// var configuration = ArgumentOrDefault<string>("configuration");
        /// // `configuration` will be `null` if the `configuration` argument is not present
        ///
        /// var number = ArgumentOrDefault<int>("number");
        /// // `number` will be 0 (zero) if the `number` argument is not present
        ///
        /// var number = ArgumentOrDefault<int?>("number");
        /// // `number` will be `null` if the `number` argument is not present (Nullable<int>)
        ///
        /// var publish = ArgumentOrDefault<bool>("publish");
        /// // `publish` will be `false` if the `publish` argument is not present
        ///
        /// var publish = ArgumentOrDefault<bool?>("publish");
        /// // `publish` will be `null` if the `publish` argument is not present (Nullable<bool>)
        ///
        /// // ...
        /// ]]>
        /// </code>
        /// </example>
        [CakeMethodAlias]
        [CakeAliasCategory("Args")]
        public static T ArgumentOrDefault<T>(this ICakeContext context, string name)
        {
            if (context is null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            return context.Argument(name, default(T));
        }
    }
}
