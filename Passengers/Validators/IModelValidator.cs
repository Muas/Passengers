using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Passengers.Validators
{
	public interface IModelValidator<T>
	{
		IEnumerable<KeyValuePair<string, string>> Validate(T model);
	}
}