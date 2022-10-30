using System;
using System.ComponentModel.DataAnnotations;
using LiveSync.Contracts;

namespace LiveSync.Client;


public class ClinicalVisit:Visit
{
    public string PatientID { get; set; }
    public string SiteCode { get; set; }
    public string FacilityName { get; set; }
    
    public string PatientPK { get; set; }
    public string VisitID { get; set; }
    public DateTime? VisitDate { get; set; }
    public string SERVICE { get; set; }
    public string VisitType { get; set; }
    public string WHOStage { get; set; }
    public string WABStage { get; set; }
    public string Pregnant { get; set; }
    public string LMP { get; set; }
    public string EDD { get; set; }
    public string Height { get; set; }
    public string Weight { get; set; }
    public string BP { get; set; }
    public string OI { get; set; }
    public DateTime? OIDate { get; set; }
    public string Adherence { get; set; }
    public string AdherenceCategory { get; set; }
    public string FamilyPlanningMethod { get; set; }
    public string PwP { get; set; }
    public string GestationAge { get; set; }
    public DateTime? NextAppointmentDate { get; set; }
    public string SubstitutionFirstlineReg { get; set; }
    public string SubstitutionFirstLineRegReason { get; set; }
    public string SubstitutionSecondLineReg { get; set; }
    public string SubstitutionSecondLineRegReason { get; set; }
    public string SecondLineRegChange { get; set; }
    public string SecondLineRegChangeReason { get; set; }
    public string Emr { get; set; }
    public string Project { get; set; }
    public int Ident { get; set; }
    public string PKV { get; set; }
    public string DifferentiatedCare { get; set; }
    public string StabilityAssessment { get; set; }
    public string KeyPopulationType { get; set; }
    public string PopulationType { get; set; }
    public string VisitBy { get; set; }
    public string Temp { get; set; }
    public string PulseRate { get; set; }
    public int? RespiratoryRate { get; set; }
    public int? OxygenSaturation { get; set; }
    public int? Muac { get; set; }
    public string NutritionalStatus { get; set; }
    public string EverHadMenses { get; set; }
    public string Breastfeeding { get; set; }
    public string Menopausal { get; set; }
    public string NoFPReason { get; set; }
    public string ProphylaxisUsed { get; set; }
    public string CTXAdherence { get; set; }
    public string CurrentRegimen { get; set; }
    public string HCWConcern { get; set; }
    public string TCAReason { get; set; }
    public string ClinicalNotes { get; set; }
    public string GeneralExamination { get; set; }
    public string SystemExamination { get; set; }
    public string Skin { get; set; }
    public string Eyes { get; set; }
    public string ENT { get; set; }
    public string Chest { get; set; }
    public string CVS { get; set; }
    public string Abdomen { get; set; }
    public string CNS { get; set; }
    public string Genitourinary { get; set; }
}
