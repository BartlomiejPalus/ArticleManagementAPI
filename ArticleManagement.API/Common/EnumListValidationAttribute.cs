using System.Collections;
using System.ComponentModel.DataAnnotations;

namespace ArticleManagementAPI.Common
{
	public class EnumListValidationAttribute : ValidationAttribute
	{
		private readonly Type _type;

		public EnumListValidationAttribute(Type type)
		{
			_type = type;
		}

		protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
		{
			if (value is IEnumerable enumerable)
			{
				foreach (var item in enumerable)
				{
					if (!Enum.IsDefined(_type, item))
						return new ValidationResult($"Invalid value {item} for enum {_type}");
				}
			}

			return ValidationResult.Success;
		}
	}
}
