using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using TestUtils.Utils;

namespace TestUtils.Models.Manifest {
    /// <summary>
    /// Reepresent a Fake Manifest
    /// </summary>
    public class FakeManifest {
        /// <summary>
        /// Used to get manifest content based on it's syntax
        /// </summary>
        /// <returns></returns>
        public override string ToString () {
            var lines = new List<string> ();
            _rnd = new Random (Seed);

            var manifestNumber = GetNDigitsRandomNumber (9);

            if (NumberOfBills == 2) {
                int bol1 = GetNDigitsRandomNumber (8);
                int bol2 = GetNDigitsRandomNumber (8);
                var b1 = bol1;
                var b2 = bol2;
                if (bol1 > bol2) {
                    b1 = bol2;
                    b2 = bol1;
                }
                var ctor1 = GetNDigitsRandomNumber (6);
                var ctor2 = GetNDigitsRandomNumber (6);
                var ctor3 = GetNDigitsRandomNumber (6);
                var plomp1 = GetNDigitsRandomNumber (6);
                var plomp2 = GetNDigitsRandomNumber (6);
                var plomp3 = GetNDigitsRandomNumber (6);

                lines.AddRange (new string[] {
                    $"'VOY','00000000000','00000000000','{manifestNumber}','{manifestNumber}','IRBSR','22Mar2017','','MFI','1','{manifestNumber}'",
                    $"'BOL','BL{b1}','00000000000','00000000000','AEJEA','AEJEA','IRBSR','IRBND','22Mar2017','','I','S','','','23','N','Y','FCL/FCL','ir','','','','','','','','{manifestNumber}','Tehran IAIS','IR','{Owner}','Ashkan','Kashan','','','Esfahan','','','','','','','Fake Mark And Number','61041900','Fake Description','1.62','UNT','UNT','','1','1','0','2.01','2.01','2.01','0','1.62','0','0','Y','',''",
                    $"'CTR','FAKU{ctor1}-6','1','2300','F{plomp1}'",
                    $"'CON','F234567','Fake Commodity 42','Fake Cargo Description 42','N','09083110','0.92','Pallet','PLT','0.17','0.96','0.18','N','','','0','C','D','N','0','0','C'",
                    $"'CON','F234567','Fake Commodity 60','Fake Cargo Description 60','N','10063000','0.7','Pallet','PLT','0.44','1.05','0.65','N','','','0','C','D','N','0','0','C'",
                    $"'BOL','BL{b2}','00000000000','00000000000','AEJEA','AEJEA','IRBSR','IRBND','22Mar2017','','I','S','','','23','N','Y','FCL/FCL','ir','','','','','','','','{manifestNumber}','Tehran IAIS','IR','{Owner}','Ashkan','Kashan','','','Esfahan','','','','','','','Fake Mark And Number','61041900','Fake Description','1.82','UNT','UNT','','1','2','0','1.2','1.2','1.2','0','1.82','0','0','Y','',''",
                    $"'CTR','FAKU{ctor2}-8','1','2300','F{plomp2}'",
                    $"'CON','F234567','Fake Commodity 30','Fake Cargo Description 30','N','{FirstHS}','0.9','Pallet','PLT','0.15','0.3','0.97','N','','','0','C','D','N','0','0','C'",
                    $"'CTR','FAKU{ctor3}-2','1','2300','F{plomp3}'",
                    $"'CON','F234567','Fake Commodity 49','Fake Cargo Description 49','N','{SecondHS}','0.67','Pallet','PLT','0.09','0.71','0.3','N','','','0','C','D','N','0','0','C'",
                    $"'CON','F234567','Fake Commodity 26','Fake Cargo Description 26','N','{ThirdHS}','0.25','Pallet','PLT','0.24','0.19','0.55','N','','','0','C','D','N','0','0','C'",
                });
            } else if (NumberOfBills == 3) {
                var bol1 = GetNDigitsRandomNumber (8);
                var bol2 = GetNDigitsRandomNumber (8);
                var bol3 = GetNDigitsRandomNumber (8);
                var b1 = bol1;
                var b2 = bol2;
                var b3 = bol3;

                if (bol1 > bol2) {
                    if (bol1 > bol3) {
                        b3 = bol3;
                        if (bol2 > bol3) {
                            b2 = bol2;
                            b1 = bol3;
                        } else {
                            b2 = bol3;
                            b1 = bol2;
                        }
                    } else {
                        b2 = bol1;
                        b3 = bol3;
                        b1 = bol2;
                    }
                } else {
                    if (bol2 > bol3) {
                        b3 = bol2;
                        if (bol1 > bol3) {
                            b2 = bol1;
                            b1 = bol3;
                        } else {
                            b2 = bol3;
                            b1 = bol1;
                        }
                    } else {
                        b2 = bol2;
                        b3 = bol3;
                        b1 = bol1;
                    }
                }

                var ctor1 = GetNDigitsRandomNumber (6);
                var ctor2 = GetNDigitsRandomNumber (6);
                var ctor3 = GetNDigitsRandomNumber (6);
                var plomp1 = GetNDigitsRandomNumber (6);
                var plomp2 = GetNDigitsRandomNumber (6);
                var plomp3 = GetNDigitsRandomNumber (6);

                lines.AddRange (new string[] {
                    $"'VOY','00000000000','00000000000','{manifestNumber}','{manifestNumber}','IRBSR','22Mar2017','','MFI','1','{manifestNumber}'",
                    $"'BOL','BL{b1}','00000000000','00000000000','AEJEA','AEJEA','IRBSR','IRBND','22Mar2017','','I','S','','','23','N','Y','FCL/FCL','ir','','','','','','','','{manifestNumber}','Tehran IAIS','IR','{Owner}','Ashkan','Kashan','','','Esfahan','','','','','','','Fake Mark And Number','61041900','Fake Description','1.27','UNT','UNT','','1','1','0','1.27','1.27','1.27','0','1.27','0','0','Y','',''",
                    $"'CTR','FAKU{ctor1}-8','1','2300','F{plomp1}'",
                    $"'CON','F234567','Fake Commodity 41','Fake Cargo Description 41','N','10064000','0.51','Pallet','PLT','0.8','0.5','0.4','N','','','0','C','D','N','0','0','C'",
                    $"'CON','F234567','Fake Commodity 35','Fake Cargo Description 35','N','10064000','0.76','Pallet','PLT','0.29','0.77','0.72','N','','','0','C','D','N','0','0','C'",
                    $"'BOL','BL{b2}','00000000000','00000000000','AEJEA','AEJEA','IRBSR','IRBND','22Mar2017','','I','S','','','23','N','Y','FCL/FCL','ir','','','','','','','','{manifestNumber}','Tehran IAIS','IR','{Owner}','Ashkan','Kashan','','','Esfahan','','','','','','','Fake Mark And Number','61041900','Fake Description','2.04','UNT','UNT','','1','2','0','1.55','1.55','1.55','0','2.04','0','0','Y','',''",
                    $"'CTR','FAKU{ctor2}-8','1','2300','F{plomp2}'",
                    $"'CON','F234567','Fake Commodity 51','Fake Cargo Description 51','N','10063000','0.96','Pallet','PLT','0.86','0.33','0.55','N','','','0','C','D','N','0','0','C'",
                    $"'CTR','FAKU{ctor3}-8','1','2300','F{plomp3}'",
                    $"'CON','F234567','Fake Commodity 18','Fake Cargo Description 18','N','10063000','0.22','Pallet','PLT','0.91','0.9','0.71','N','','','0','C','D','N','0','0','C'",
                    $"'CON','F234567','Fake Commodity 51','Fake Cargo Description 51','N','10064000','0.86','Pallet','PLT','0.46','0.32','0.8','N','','','0','C','D','N','0','0','C'",
                    $"'BOL','BL{b3}','00000000000','00000000000','AEJEA','AEJEA','IRBSR','IRBND','22Mar2017','','I','S','','','23','N','Y','FCL/FCL','ir','','','','','','','','{manifestNumber}','Tehran IAIS','IR','{Owner}','Ashkan','Kashan','','','Esfahan','','','','','','','Fake Mark And Number','61041900','Fake Description','0','UNT','UNT','','1','1','0','1.41','1.41','1.41','0','0','0','0','Y','',''",
                    $"'CTR','BULK123456-1','1','2300','SE12341'",
                    $"'CON','F234567','Fake Commodity 49','Fake Cargo Description 49','N','10063000','0','Pallet','PLT','0','0.41','0.35','N','','','0','C','D','N','0','0','C'",
                    $"'CON','F234567','Fake Commodity 49','Fake Cargo Description 49','N','10063000','0','Pallet','PLT','0','0.44','0.17','N','','','0','C','D','N','0','0','C'",
                    $"'CON','F234567','Fake Commodity 24','Fake Cargo Description 24','N','10063000','0','Pallet','PLT','0','0.11','0.62','N','','','0','C','D','N','0','0','C'",
                    $"'CON','F234567','Fake Commodity 38','Fake Cargo Description 38','N','10064000','0','Pallet','PLT','0','0.45','0.29','N','','','0','C','D','N','0','0','C'",
                });
            } else {
                throw new Exception ($"could not generate fake manifest of {NumberOfBills} bill");
            }

            // We dont use Environment.NewLine in below as the content may be served in a linux based server
            return String.Join ("\n", lines).Replace ('\'', '"');
        }

        private Random _rnd;
        private int GetNDigitsRandomNumber (int digits) {
            var min = 1;
            for (int i = 0; i < digits - 1; i++) {
                min *= 10;
            }
            var max = min * 10;

            return _rnd.Next (min, max);
        }

        /// <summary>
        /// Owner of Manifest
        /// </summary>
        [Required]
        public string Owner { get; set; }

        /// <summary>
        /// Number of Bills inside manifest
        /// </summary>
        [Required]
        [WhiteList (2, 3)]
        public int? NumberOfBills { get; set; }

        /// <summary>
        /// File Name of manifest
        /// </summary>
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// Seed that used for random number generating
        /// </summary>
        public int Seed { get; set; }

        /// <summary>
        /// HS that used number value_commodity
        /// </summary>
        public string FirstHS { get; set; }

        /// <summary>
        /// HS2 that used number value_commodity
        /// </summary>
        public string SecondHS { get; set; }

        /// <summary>
        /// HS3 that used number value_commodity
        /// </summary>
        public string ThirdHS { get; set; }
    }

}