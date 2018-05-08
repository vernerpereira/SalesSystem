using System;
using SalesSystem.Common.Resources;
using SalesSystem.Common.Validation;

namespace SalesSystem.Domain.Entities
{
    public abstract class EntityBase
    {
        public int Id { get; set; }
        public DateTime PersistDate { get; private set; }
        public bool IsActive { get; private set; }

        public void SetIsActive(bool isActive)
        {
            AssertionConcern.AssertArgumentNotNull(isActive, Errors.IsActiveRequired);
            IsActive = isActive;
        }
    }
}
