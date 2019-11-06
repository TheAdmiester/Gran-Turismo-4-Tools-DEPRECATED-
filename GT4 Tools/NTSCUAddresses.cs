namespace GT4_Tools
{
    public class NTSCUAddresses : Addresses
    {
        // SCUS-97328
        protected override uint GarageBase => memoryBase + 0x00A1F7C8;
    }
}
