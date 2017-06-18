using System;
using System.Collections.Generic;

using Bytes2you.Validation;
using ProjectManager.Framework.Core.Commands.Contracts;

namespace ProjectManager.Framework.Services
{
    public class CachingService : ICachingService
    {
        private readonly TimeSpan duration;
        private DateTime timeExpiring;
        private IDictionary<string, object> cache;

        public CachingService(TimeSpan duration)
        {
            Guard.WhenArgument(duration, "duration").IsLessThan(TimeSpan.Zero).Throw();

            this.duration = duration;
            this.timeExpiring = DateTime.UtcNow;
            this.cache = new Dictionary<string, object>();
        }

        public void ResetCache()
        {
            this.cache = new Dictionary<string, object>();
            this.timeExpiring = DateTime.UtcNow + this.duration;
        }

        public bool IsExpired
        {
            get
            {
                if (this.timeExpiring < DateTime.UtcNow)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        protected IDictionary<string, object> Cache
        {
            get
            {
                return this.cache;
            }
        }

        protected DateTime TimeExpiring
        {
            get
            {
                return this.timeExpiring;
            }
        }

        public object GetCacheValue(string className, string methodName)
        {
            return this.cache[$"{className}.{methodName}"];
        }

        public void AddCacheValue(string className, string methodName, object value)
        {
            this.cache.Add($"{className}.{methodName}", value);
        }
    }
}
