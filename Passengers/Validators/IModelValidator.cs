using System.Collections.Generic;

namespace Passengers.Validators
{
	public interface IModelValidator<T>
	{
		IEnumerable<KeyValuePair<string, string>> Validate(T model);
	}
}