namespace ConstructionProject.Model
{
    public class ProjectModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public int StageId { get; set; }
        public int CategoryId { get; set; }
        public DateTime ConstructionStartDate { get; set; }
        public string Details_Description { get; set; }
        public int CreatorID { get; set; }
    }
}
