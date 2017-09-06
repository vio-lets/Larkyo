using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Larkyo.Core.Data
{
    public abstract class PropertyExpression<T, TProperty>
    {
        protected PropertyExpression(Expression<Func<T, TProperty>> expression)
        {
            this.Expression = expression;
        }

        public Expression<Func<T, TProperty>> Expression
        {
            get;
            private set;
        }
    }
}
