using System;
using System.Collections.Generic;
using System.Text;
using Core.Utilities.Results.Abstract;

namespace Core.Utilities.Results.Concrete
{
    public class DataResult<TEntity> : Result, IDataResult<TEntity>
    {
        public DataResult(TEntity data, bool success, string message) : base(success, message)
        {
            Data = data;
        }
        public DataResult(TEntity data, bool success) : base(success)
        {
            Data = data;
        }
        public TEntity Data { get; }
    }
}
