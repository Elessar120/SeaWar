namespace AMVCC.Views
{
    public class SeaWarRefineryView : SeaWarElement
    {
        public float health;
        public float storedOil;
        public float productionRate;

        private void Awake()
        {
            health = Application.model.refineryModel.health;
            productionRate = Application.model.refineryModel.productionRate;
            storedOil = Application.model.refineryModel.storedOil;

        }

        private void Start()
        {
            
           
          }   
        
    }
}