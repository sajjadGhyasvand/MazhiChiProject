using GeneralManagement.Application.Contracts.GeneralSetting;

namespace GeneralManagement.Application.Contracts.Certificate
{
    public class EditCertificate: CreateCertificate
    {
        public long Id { get; set; }
    }
}