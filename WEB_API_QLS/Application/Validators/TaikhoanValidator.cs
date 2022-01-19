using FluentValidation;
using WEB_API_QLS.Domain.Entities;

namespace WEB_API_QLS.Application.Validators
{
    public class TaikhoanValidator : AbstractValidator<Taikhoan>
    {
        public TaikhoanValidator()
        {
            RuleFor(m => m.Username)
                .NotEmpty().WithMessage("Hãy nhập tên người dùng");
            RuleFor(m => m.Email)
                .NotEmpty().WithMessage("Hãy nhập địa chỉ email")
                .EmailAddress().WithMessage("Địa chỉ email nhập vào không đúng định dạng");
            RuleFor(m => m.Password)
               .NotEmpty().WithMessage("Hãy nhập password");
        }
    }
}
