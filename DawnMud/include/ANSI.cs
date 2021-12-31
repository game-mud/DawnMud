namespace DawnMud.include
{
    public static class ANSI
    {
        public static string ESC = "";                     /* ESC      */
        public static string CSI = ESC + "[";
        public static string BLK = ESC + "[30m";          /* Black    */
        public static string RED = ESC + "[31m";          /* Red      */
        public static string GRN = ESC + "[32m";          /* Green    */
        public static string YEL = ESC + "[33m";          /* Yellow   */
        public static string BLU = ESC + "[34m";          /* Blue     */
        public static string MAG = ESC + "[35m";          /* Magenta  */
        public static string CYN = ESC + "[36m";          /* Cyan     */
        public static string WHT = ESC + "[37m";          /* White    */

        /*   Hi Intensity Foreground Colors   */

        public static string HIR = ESC + "[1;31m";        /* Red      */
        public static string HIG = ESC + "[1;32m";        /* Green    */
        public static string HIY = ESC + "[1;33m";        /* Yellow   */
        public static string HIB = ESC + "[1;34m";        /* Blue     */
        public static string HIM = ESC + "[1;35m";        /* Magenta  */
        public static string HIC = ESC + "[1;36m";        /* Cyan     */
        public static string HIW = ESC + "[1;37m";        /* White    */

        /* High Intensity Background Colors  */

        public static string HBRED = ESC + "[41;1m";       /* Red      */
        public static string HBGRN = ESC + "[42;1m";       /* Green    */
        public static string HBYEL = ESC + "[43;1m";       /* Yellow   */
        public static string HBBLU = ESC + "[44;1m";       /* Blue     */
        public static string HBMAG = ESC + "[45;1m";       /* Magenta  */
        public static string HBCYN = ESC + "[46;1m";       /* Cyan     */
        public static string HBWHT = ESC + "[47;1m";       /* White    */

        /*  Background Colors  */

        public static string BBLK = ESC + "[40m";          /* Black    */
        public static string BRED = ESC + "[41m";          /* Red      */
        public static string BGRN = ESC + "[42m";          /* Green    */
        public static string BYEL = ESC + "[43m";          /* Yellow   */
        public static string BBLU = ESC + "[44m";          /* Blue     */
        public static string BMAG = ESC + "[45m";          /* Magenta  */
        public static string BCYN = ESC + "[46m";          /* Cyan     */
        public static string BWHT = ESC + "[47m";          /* White    */

        public static string NOR = ESC + "[2;37;0m";     /* Puts everything back to normal */
    }
}
