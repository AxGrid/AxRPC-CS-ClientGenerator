namespace AxRPCEventGenerator.Data
{
    /**
     *  String getHttpEntryPoint();
    String getEventObject();
    String getEventObjectFullName();

    String getEventCollectionObject();
    String getEventCollectionObjectFullName();

     */
    public class Event
    {
        public string HttpEntryPoint { get; set; }
        
        public string EventObject { get; set; }
        public string EventObjectFullName { get; set; }
        
        public string EventCollectionObject { get; set; }
        public string EventCollectionObjectFullName { get; set; }
    }
}