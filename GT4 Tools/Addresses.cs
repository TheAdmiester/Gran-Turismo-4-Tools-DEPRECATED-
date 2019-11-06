namespace GT4_Tools
{
    public abstract class Addresses
    {
        protected const uint memoryBase = 0x20000000;
        protected virtual uint GarageBase => memoryBase + 0x00A1F7C8;

        // Hybrid parts (current car)
        public uint Engine => GarageBase + 0x40;
        public uint Drivetrain => GarageBase + 0x48;
        public uint NATune => GarageBase + 0xB0;
        public uint Turbo => GarageBase + 0xB8;
        public uint Exhaust => GarageBase + 0xD8;
        public uint Supercharger => GarageBase + 0x110;

        // Camera settings
        public static string MEM_FOVA = "0x21FDDCD4"; // Arcade FOV
        public static string MEM_FOVG = "0x21FE1294"; // GT Mode FOV
        public static string MEM_FOVS = "0x21FC2914"; // Special Condition FOV
        public static string MEM_CAM = "0x2034513C"; // Camera stiffness

        // Arcade mode
        public static string MEM_PLR = "0x20A0BF70"; // Player
        public static string MEM_CR1 = "0x20A0BFD8"; // AI 1
        public static string MEM_CR2 = "0x20A0C040"; // AI 2
        public static string MEM_CR3 = "0x20A0C0A8";
        public static string MEM_CR4 = "0x20A0C110";
        public static string MEM_CR5 = "0x20A0C178";
        public static string MEM_TRK = "0x20A0BE94"; // Track

        // Vehicle bodies
        public static string MEM_206 = "0x20BBDB8E"; // Peugeot 206 Rally Car
        public static string MEM_CAL = "0x20BBD690"; // Opel Calibra Touring Car
        public static string MEM_CRS = "0x20BBD718"; // Opel Corsa
        public static string MEM_GT1 = "0x20BBF46E"; // Toyota GT-One
        public static string MEM_MRC = "0x20BBC81E"; // Mini Marcos GT
        public static string MEM_SPS = "0x20BBD82E"; // Opel Speedster
        public static string MEM_SPT = "0x20BBD89A"; // Opel Speedster Turbo
        public static string MEM_SUP = "0x20BBF272"; // Castrol Tom's Supra (2001)
        public static string MEM_TIG = "0x20BBD622"; // Opel Tigra
        public static string MEM_VEC = "0x20BBD69C"; // Opel Vectra
    }
}
