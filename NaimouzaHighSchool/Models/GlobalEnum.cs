namespace NaimouzaHighSchool.Models
{
    public enum SplitAddrX { AddrLane1, AddrLane2, PO, PS, Dist, PIN};

    public enum StudentProperty {
        Aadhaar,
        Name,
        FatherName,
        MotherName,
        Dob,
        Gender,
        SocialCat,
        Religion,
        MotherTongue,
        Locality,
        DoA,
        AdmNo,
        IsBpl,
        IsDisadvantaged,
        GettingFreeEdu,
        CurrYearClass,
        PrevYearClass,
        IfClassOne,
        DaysAttended,
        InstrMedium,
        DisabilityType,
        CWSNFacility,
        FacilityUniform,
        FacilityBooks,
        FacilityTransport,
        FacilityEscort,
        FacilityBicycle,
        FacilityHostel,
        FacilityTraining,
        IsHomeLess,
        LastExamResult,
        LastExamPercentage,
        CurrSchoolingStatus,
        HsStream,
        VocSector,
        VocJobRoll,
        VocCompNSQF,
        VocOptedFor,
        VocPlament,
        VocSalaryOffered,
        BankAcc,
        IFSC,
        Mobile,
        Email
    };

    public enum SearchType { Name, ID, Aadhaar, Father, Village, SocialCategory, Roll };

    public enum IdNumberType { Aadhaar, Mobile, StudentId};

    public enum StaffColName { VacancyStatus, Designation, Subject, SalarySource, EmployeeGroup, ApprvQualification, PayBand};
}