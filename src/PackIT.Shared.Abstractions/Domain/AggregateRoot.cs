using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackIT.Shared.Abstractions.Domain
{
    public abstract class AggregateRoot<T>
    {

        private readonly List<IDomainEvent> _events = new();
        public IEnumerable<IDomainEvent> Events => _events;

        protected void AddEvent(IDomainEvent @event)
        {
            if (!_events.Any() && !_versionIncremented)
            {
                Version++;
                _versionIncremented = true;
            }

            _events.Add(@event);

        }

        public T Id { get; protected set; }
        public int Version { get; protected set; }

        private bool _versionIncremented;


        public void ClearEvents() => _events.Clear();

        protected void IncrementVersion()
        {
            if(_versionIncremented)
            {
                return;
            }

            Version++;
            _versionIncremented = true;
        }
    }
}
