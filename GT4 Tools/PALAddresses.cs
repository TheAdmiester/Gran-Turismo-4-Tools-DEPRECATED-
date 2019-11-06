namespace GT4_Tools
{
    public class PALAddresses : Addresses
    {
        // SCES-51719
        protected override uint GarageBase => memoryBase + 0x00A2A5C8;
    }
}
