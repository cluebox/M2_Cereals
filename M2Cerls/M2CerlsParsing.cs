using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using SpssLib.DataReader;
using SpssLib.SpssDataset;
using System.Data.SqlClient;

namespace M2Cerls
{
    class M2CerlsParsing
    {
        static void Main(string[] args)
        {
            int SURVEY_ID = 600500;
            string SURVEY_PERIOD = "2018-12-31";//survey period
            string country = "INDONESIA";//survey country
            Insertion_M2cerls iobj = new Insertion_M2cerls();
            string questions = "iobs,weight,r5,r14,r2,r7,r13,rw,r26_1,r27c,r31c,r19_1,r19_2,r19_3,r19_4,r19_5,r19_6,r19_7,r20,r27a,r27b_11,r27b_12,r27b_15,r27b_16,r27b_17,r27b_18,r27b_24,r27b_30,r27b_36,r27b_41,r27b_52,r27b_53,r27b_83,r30a_11,r30a_12,r30a_15,r30a_16,r30a_17,r30a_18,r30a_24,r30a_30,r30a_36,r30a_41,r30a_52,r30a_53,r30a_83,r27d,r27e_11,r27e_12,r27e_15,r27e_16,r27e_17,r27e_18,r27e_24,r27e_30,r27e_36,r27e_41,r27e_52,r27e_53,r27e_83,r30b_11,r30b_12,r30b_15,r30b_16,r30b_17,r30b_18,r30b_24,r30b_30,r30b_36,r30b_41,r30b_52,r30b_53,r30b_83,r31a_11,r31a_12,r31a_15,r31a_16,r31a_17,r31a_18,r31a_24,r31a_30,r31a_36,r31a_41,r31a_52,r31a_53,r31a_83,r31b_11,r31b_12,r31b_15,r31b_16,r31b_17,r31b_18,r31b_24,r31b_30,r31b_36,r31b_41,r31b_52,r31b_53,r31b_83,r24a_1,r24a_2,r24a_3,r24a_4,r24a_5,r24br1_1,r24br1_2,r24br1_3,r24br1_4,r24br1_5,r24br1_6,r24br2_1,r24br2_2,r24br2_3,r24br2_4,r24br2_5,r24br2_6,r24br3_1,r24br3_2,r24br3_3,r24br3_4,r24br3_5,r24br3_6,r24br4_1,r24br4_2,r24br4_3,r24br4_4,r24br4_5,r24br4_6,r24br5_1,r24br5_2,r24br5_3,r24br5_4,r24br5_5,r24br5_6,r27an_1,r27an_2,r27an_10,r27an_12,r27bn_1,r27bn_2,r27bn_10,r27bn_12,r30an_1,r30an_2,r30an_10,r30an_12,r27dn_1,r27dn_2,r27dn_10,r27dn_12,r27en_1,r27en_2,r27en_10,r27en_12,r30bn_1,r30bn_2,r30bn_10,r30bn_12,r27cn_1,r27cn_2,r27cn_10,r27cn_12,r31cn_1,r31cn_2,r31cn_10,r31cn_12,r31an_1,r31an_2,r31an_10,r31an_12,r31bn_1,r31bn_2,r31bn_10,r31bn_12,r33c4_1,r33c4_2,r33c4_4,r33c4_6,r33c4_8,r33c4_9,r33c4_12,r33c4_13,r33c4_14,r33c5_1,r33c5_2,r33c5_4,r33c5_6,r33c5_8,r33c5_9,r33c5_12,r33c5_13,r33c5_14,r33c7_1,r33c7_2,r33c7_4,r33c7_6,r33c7_8,r33c7_9,r33c7_12,r33c7_13,r33c7_14,r33c9_1,r33c9_2,r33c9_4,r33c9_6,r33c9_8,r33c9_9,r33c9_12,r33c9_13,r33c9_14,r33c10_1,r33c10_2,r33c10_4,r33c10_6,r33c10_8,r33c10_9,r33c10_12,r33c10_13,r33c10_14,r27b_89,r30a_89,r27e_89,r30b_89,r31a_89,r31b_89,r27b_90,r30a_90,r27e_90,r30b_90,r31a_90,r31b_90,r27an_22,r27bn_22,r30an_22,r27dn_22,r27en_22,r30bn_22,r31an_22,r31bn_22,r31cn_22,r27cn_22,r252r1_2,r252r6_2,r252r9_2,r252r11_2,r252r8_2,r252r7_2,r252r4_2,r252r1_4,r252r6_4,r252r9_4,r252r11_4,r252r8_4,r252r7_4,r252r4_4,r252r1_6,r252r6_6,r252r9_6,r252r11_6,r252r8_6,r252r7_6,r252r4_6,r137a_11,r137a_12,r137a_15,r137a_16,r137a_17,r137a_18,r137a_24,r137a_30,r137a_36,r137a_41,r137a_52,r137a_53,r137a_83,r137a_90,r137a_89,r291_11,r291_12,r291_15,r291_16,r291_17,r291_18,r291_24,r291_30,r291_36,r291_41,r291_52,r291_53,r291_83,r291_90,r291_89,r137an_2,r137an_10,r137an_12,r137an_1,r137an_22,r291n_2,r291n_10,r291n_12,r291n_1,r291n_22";// dashboard variable value
           //string questions = "r137a_11,r137a_12,r137a_15,r137a_16,r137a_17,r137a_18,r137a_24,r137a_30,r137a_36,r137a_41,r137a_52,r137a_53,r137a_83,r137a_90,r137a_89,r291_11,r291_12,r291_15,r291_16,r291_17,r291_18,r291_24,r291_30,r291_36,r291_41,r291_52,r291_53,r291_83,r291_90,r291_89,r137an_2,r137an_10,r137an_12,r137an_1,r137an_22,r291n_2,r291n_10,r291n_12,r291n_1,r291n_22";
            string[] spss_variable_name = questions.Split(',');
            SpssReader spssDataset;
            using (FileStream fileStream = new FileStream(@"C:\Users\rahul\Desktop\M2 CEREALS DEC\M2CEREALS_DEC2018.sav", FileMode.Open, FileAccess.Read, FileShare.Read, 2048 * 10, FileOptions.SequentialScan))
            {
                spssDataset = new SpssReader(fileStream); // Create the reader, this will read the file header
                foreach (string spss_v in spss_variable_name)
                {
                    foreach (var variable in spssDataset.Variables)  // Iterate through all the varaibles
                    {

                        if (variable.Name.Equals(spss_v))
                        {
                            foreach (KeyValuePair<double, string> label in variable.ValueLabels)
                            {
                                string VARIABLE_NAME = spss_v;
                                string VARIABLE_NAME_SUB_NAME = variable.Name;
                                string VARIABLE_ID = label.Key.ToString();
                                string VARIABLE_VALUE = label.Value;
                                string VARIABLE_NAME_QUESTION = variable.Label;
                                string BASE_VARIABLE_NAME = variable.Name;
                             //iobj.insert_Dashboard_variable_values(VARIABLE_NAME, VARIABLE_NAME_SUB_NAME, VARIABLE_ID, VARIABLE_VALUE, VARIABLE_NAME_QUESTION, SURVEY_ID, country, BASE_VARIABLE_NAME, SURVEY_PERIOD);
                            }
                        }
                    }
                }
                // Iterate through all data rows in the file
                foreach (var record in spssDataset.Records)
                {
                    string userID = null;
                    string variable_name;
                    decimal weightage = 0;
                    string u_id = "-- Not Available --";
                    string userEmail = "-- Not Available --";
                    string firstName = "-- Not Available --";
                    string lastName = "-- Not Available --";
                    string UserStatus = "-- Not Available --";
                    string gender = "-- Not Available --";
                    string maritalStatus = "-- Not Available --";
                    string education = "-- Not Available --";
                    string race = "-- Not Available --";
                    string religion = "-- Not Available --";
                    string postCode = "-- Not Available --";
                    string city = "-- Not Available --";
                    string subDistrict = "-- Not Available --";
                    string village = "-- Not Available --";
                    string incomeRange = "-- Not Available --";
                    string industryName = "-- Not Available --";
                    string occupation = "-- Not Available --";
                    string location = "-- Not Available --";
                    string AgeGroup = "-- Not Available --";
                    string ses = "-- Not Available --";
                    string period = "-- Not Available --";
                    string cerealpanel = "-- Not Available --";
                    string r27c = "-- Not Available --";
                    string r31c = "-- Not Available --";
                    string r19_1 = "-- Not Available --";
                    string r19_2 = "-- Not Available --";
                    string r19_3 = "-- Not Available --";
                    string r19_4 = "-- Not Available --";
                    string r19_5 = "-- Not Available --";
                    string r19_6 = "-- Not Available --";
                    string r19_7 = "-- Not Available --";
                    string r20 = "-- Not Available --";
                    string r27a = "-- Not Available --";
                    string r27b_11 = "-- Not Available --";
                    string r27b_12 = "-- Not Available --";
                    string r27b_15 = "-- Not Available --";
                    string r27b_16 = "-- Not Available --";
                    string r27b_17 = "-- Not Available --";
                    string r27b_18 = "-- Not Available --";
                    string r27b_24 = "-- Not Available --";
                    string r27b_30 = "-- Not Available --";
                    string r27b_36 = "-- Not Available --";
                    string r27b_41 = "-- Not Available --";
                    string r27b_52 = "-- Not Available --";
                    string r27b_53 = "-- Not Available --";
                    string r27b_83 = "-- Not Available --";
                    string r30a_11 = "-- Not Available --";
                    string r30a_12 = "-- Not Available --";
                    string r30a_15 = "-- Not Available --";
                    string r30a_16 = "-- Not Available --";
                    string r30a_17 = "-- Not Available --";
                    string r30a_18 = "-- Not Available --";
                    string r30a_24 = "-- Not Available --";
                    string r30a_30 = "-- Not Available --";
                    string r30a_36 = "-- Not Available --";
                    string r30a_41 = "-- Not Available --";
                    string r30a_52 = "-- Not Available --";
                    string r30a_53 = "-- Not Available --";
                    string r30a_83 = "-- Not Available --";
                    string r27d = "-- Not Available --";
                    string r27e_11 = "-- Not Available --";
                    string r27e_12 = "-- Not Available --";
                    string r27e_15 = "-- Not Available --";
                    string r27e_16 = "-- Not Available --";
                    string r27e_17 = "-- Not Available --";
                    string r27e_18 = "-- Not Available --";
                    string r27e_24 = "-- Not Available --";
                    string r27e_30 = "-- Not Available --";
                    string r27e_36 = "-- Not Available --";
                    string r27e_41 = "-- Not Available --";
                    string r27e_52 = "-- Not Available --";
                    string r27e_53 = "-- Not Available --";
                    string r27e_83 = "-- Not Available --";
                    string r30b_11 = "-- Not Available --";
                    string r30b_12 = "-- Not Available --";
                    string r30b_15 = "-- Not Available --";
                    string r30b_16 = "-- Not Available --";
                    string r30b_17 = "-- Not Available --";
                    string r30b_18 = "-- Not Available --";
                    string r30b_24 = "-- Not Available --";
                    string r30b_30 = "-- Not Available --";
                    string r30b_36 = "-- Not Available --";
                    string r30b_41 = "-- Not Available --";
                    string r30b_52 = "-- Not Available --";
                    string r30b_53 = "-- Not Available --";
                    string r30b_83 = "-- Not Available --";
                    string r31a_11 = "-- Not Available --";
                    string r31a_12 = "-- Not Available --";
                    string r31a_15 = "-- Not Available --";
                    string r31a_16 = "-- Not Available --";
                    string r31a_17 = "-- Not Available --";
                    string r31a_18 = "-- Not Available --";
                    string r31a_24 = "-- Not Available --";
                    string r31a_30 = "-- Not Available --";
                    string r31a_36 = "-- Not Available --";
                    string r31a_41 = "-- Not Available --";
                    string r31a_52 = "-- Not Available --";
                    string r31a_53 = "-- Not Available --";
                    string r31a_83 = "-- Not Available --";
                    string r31b_11 = "-- Not Available --";
                    string r31b_12 = "-- Not Available --";
                    string r31b_15 = "-- Not Available --";
                    string r31b_16 = "-- Not Available --";
                    string r31b_17 = "-- Not Available --";
                    string r31b_18 = "-- Not Available --";
                    string r31b_24 = "-- Not Available --";
                    string r31b_30 = "-- Not Available --";
                    string r31b_36 = "-- Not Available --";
                    string r31b_41 = "-- Not Available --";
                    string r31b_52 = "-- Not Available --";
                    string r31b_53 = "-- Not Available --";
                    string r31b_83 = "-- Not Available --";
                    string r24a_1 = "-- Not Available --";
                    string r24a_2 = "-- Not Available --";
                    string r24a_3 = "-- Not Available --";
                    string r24a_4 = "-- Not Available --";
                    string r24a_5 = "-- Not Available --";
                    string r24br1_1 = "-- Not Available --";
                    string r24br1_2 = "-- Not Available --";
                    string r24br1_3 = "-- Not Available --";
                    string r24br1_4 = "-- Not Available --";
                    string r24br1_5 = "-- Not Available --";
                    string r24br1_6 = "-- Not Available --";
                    string r24br2_1 = "-- Not Available --";
                    string r24br2_2 = "-- Not Available --";
                    string r24br2_3 = "-- Not Available --";
                    string r24br2_4 = "-- Not Available --";
                    string r24br2_5 = "-- Not Available --";
                    string r24br2_6 = "-- Not Available --";
                    string r24br3_1 = "-- Not Available --";
                    string r24br3_2 = "-- Not Available --";
                    string r24br3_3 = "-- Not Available --";
                    string r24br3_4 = "-- Not Available --";
                    string r24br3_5 = "-- Not Available --";
                    string r24br3_6 = "-- Not Available --";
                    string r24br4_1 = "-- Not Available --";
                    string r24br4_2 = "-- Not Available --";
                    string r24br4_3 = "-- Not Available --";
                    string r24br4_4 = "-- Not Available --";
                    string r24br4_5 = "-- Not Available --";
                    string r24br4_6 = "-- Not Available --";
                    string r24br5_1 = "-- Not Available --";
                    string r24br5_2 = "-- Not Available --";
                    string r24br5_3 = "-- Not Available --";
                    string r24br5_4 = "-- Not Available --";
                    string r24br5_5 = "-- Not Available --";
                    string r24br5_6 = "-- Not Available --";
                    string r27an_1 = "-- Not Available --";
                    string r27an_2 = "-- Not Available --";
                    string r27an_10 = "-- Not Available --";
                    string r27an_12 = "-- Not Available --";
                    string r27bn_1 = "-- Not Available --";
                    string r27bn_2 = "-- Not Available --";
                    string r27bn_10 = "-- Not Available --";
                    string r27bn_12 = "-- Not Available --";
                    string r30an_1 = "-- Not Available --";
                    string r30an_2 = "-- Not Available --";
                    string r30an_10 = "-- Not Available --";
                    string r30an_12 = "-- Not Available --";
                    string r27dn_1 = "-- Not Available --";
                    string r27dn_2 = "-- Not Available --";
                    string r27dn_10 = "-- Not Available --";
                    string r27dn_12 = "-- Not Available --";
                    string r27en_1 = "-- Not Available --";
                    string r27en_2 = "-- Not Available --";
                    string r27en_10 = "-- Not Available --";
                    string r27en_12 = "-- Not Available --";
                    string r30bn_1 = "-- Not Available --";
                    string r30bn_2 = "-- Not Available --";
                    string r30bn_10 = "-- Not Available --";
                    string r30bn_12 = "-- Not Available --";
                    string r27cn_1 = "-- Not Available --";
                    string r27cn_2 = "-- Not Available --";
                    string r27cn_10 = "-- Not Available --";
                    string r27cn_12 = "-- Not Available --";
                    string r31cn_1 = "-- Not Available --";
                    string r31cn_2 = "-- Not Available --";
                    string r31cn_10 = "-- Not Available --";
                    string r31cn_12 = "-- Not Available --";
                    string r31an_1 = "-- Not Available --";
                    string r31an_2 = "-- Not Available --";
                    string r31an_10 = "-- Not Available --";
                    string r31an_12 = "-- Not Available --";
                    string r31bn_1 = "-- Not Available --";
                    string r31bn_2 = "-- Not Available --";
                    string r31bn_10 = "-- Not Available --";
                    string r31bn_12 = "-- Not Available --";
                    string r33c4_1 = "-- Not Available --";
                    string r33c4_2 = "-- Not Available --";
                    string r33c4_4 = "-- Not Available --";
                    string r33c4_6 = "-- Not Available --";
                    string r33c4_8 = "-- Not Available --";
                    string r33c4_9 = "-- Not Available --";
                    string r33c4_12 = "-- Not Available --";
                    string r33c4_13 = "-- Not Available --";
                    string r33c4_14 = "-- Not Available --";
                    string r33c5_1 = "-- Not Available --";
                    string r33c5_2 = "-- Not Available --";
                    string r33c5_4 = "-- Not Available --";
                    string r33c5_6 = "-- Not Available --";
                    string r33c5_8 = "-- Not Available --";
                    string r33c5_9 = "-- Not Available --";
                    string r33c5_12 = "-- Not Available --";
                    string r33c5_13 = "-- Not Available --";
                    string r33c5_14 = "-- Not Available --";
                    string r33c7_1 = "-- Not Available --";
                    string r33c7_2 = "-- Not Available --";
                    string r33c7_4 = "-- Not Available --";
                    string r33c7_6 = "-- Not Available --";
                    string r33c7_8 = "-- Not Available --";
                    string r33c7_9 = "-- Not Available --";
                    string r33c7_12 = "-- Not Available --";
                    string r33c7_13 = "-- Not Available --";
                    string r33c7_14 = "-- Not Available --";
                    string r33c9_1 = "-- Not Available --";
                    string r33c9_2 = "-- Not Available --";
                    string r33c9_4 = "-- Not Available --";
                    string r33c9_6 = "-- Not Available --";
                    string r33c9_8 = "-- Not Available --";
                    string r33c9_9 = "-- Not Available --";
                    string r33c9_12 = "-- Not Available --";
                    string r33c9_13 = "-- Not Available --";
                    string r33c9_14 = "-- Not Available --";
                    string r33c10_1 = "-- Not Available --";
                    string r33c10_2 = "-- Not Available --";
                    string r33c10_4 = "-- Not Available --";
                    string r33c10_6 = "-- Not Available --";
                    string r33c10_8 = "-- Not Available --";
                    string r33c10_9 = "-- Not Available --";
                    string r33c10_12 = "-- Not Available --";
                    string r33c10_13 = "-- Not Available --";
                    string r33c10_14 = "-- Not Available --";
                    string BrSpontGoW_Chocolate = "-- Not Available --";
                    string BrAidGoW_Chocolate = "-- Not Available --";
                    string AdSpontGoW_Chocolate = "-- Not Available --";
                    string AdAidGoW_Chocolate = "-- Not Available --";
                    string ConsL3MGoW_Chocolate = "-- Not Available --";
                    string ConsLMGoW_Chocolate = "-- Not Available --";
                    string BrSpontGoW_Vanilla = "-- Not Available --";
                    string BrAidGoW_Vanilla = "-- Not Available --";
                    string AdSpontGoW_Vanilla = "-- Not Available --";
                    string AdAidGoW_Vanilla = "-- Not Available --";
                    string ConsL3MGoW_Vanilla = "-- Not Available --";
                    string ConsLMGoW_Vanilla = "-- Not Available --";
                    string BrTom_GoWell_NET = "-- Not Available --";
                    string BrSpont_GoWell_NET = "-- Not Available --";
                    string BrAided_GoWell_NET = "-- Not Available --";
                    string AdTom_GoWell_NET = "-- Not Available --";
                    string AdSpont_GoWell_NET = "-- Not Available --";
                    string AdAided_GoWell_NET = "-- Not Available --";
                    string Fav_GoWell_NET = "-- Not Available --";
                    string Bumo_GoWell_NET = "-- Not Available --";
                    string ConsL3M_GoWell_NET = "-- Not Available --";
                    string ConsLM_GoWell_NET = "-- Not Available --";
                    string r137a_11 = "-- Not Available --";
                    string r137a_12 = "-- Not Available --";
                    string r137a_15 = "-- Not Available --";
                    string r137a_16 = "-- Not Available --";
                    string r137a_17 = "-- Not Available --";
                    string r137a_18 = "-- Not Available --";
                    string r137a_24 = "-- Not Available --";
                    string r137a_30 = "-- Not Available --";
                    string r137a_36 = "-- Not Available --";
                    string r137a_41 = "-- Not Available --";
                    string r137a_52 = "-- Not Available --";
                    string r137a_53 = "-- Not Available --";
                    string r137a_83 = "-- Not Available --";
                    string ConsP1WGoW_Vanilla = "-- Not Available --";
                    string ConsP1WGoW_Chocolate = "-- Not Available --";
                    string r291_11 = "-- Not Available --";
                    string r291_12 = "-- Not Available --";
                    string r291_15 = "-- Not Available --";
                    string r291_16 = "-- Not Available --";
                    string r291_17 = "-- Not Available --";
                    string r291_18 = "-- Not Available --";
                    string r291_24 = "-- Not Available --";
                    string r291_30 = "-- Not Available --";
                    string r291_36 = "-- Not Available --";
                    string r291_41 = "-- Not Available --";
                    string r291_52 = "-- Not Available --";
                    string r291_53 = "-- Not Available --";
                    string r291_83 = "-- Not Available --";
                    string ConsP1DGoW_Vanilla = "-- Not Available --";
                    string ConsP1DGoW_Chocolate = "-- Not Available --";
                    string ConsP1W_Energen = "-- Not Available --";
                    string r137an_10 = "-- Not Available --";
                    string r137an_12 = "-- Not Available --";
                    string r137an_1 = "-- Not Available --";
                    string ConsP1W_GoWell_NET = "-- Not Available --";
                    string ConsP1D_Energen = "-- Not Available --";
                    string r291n_10 = "-- Not Available --";
                    string r291n_12 = "-- Not Available --";
                    string r291n_1 = "-- Not Available --";
                    string ConsP1D_GoWell_NET = "-- Not Available --";
                    foreach (var variable in spssDataset.Variables)
                    {
                        foreach (string spss_v in spss_variable_name)
                        {
                            if (variable.Name.Equals(spss_v))
                            {
                                variable_name = variable.Name;
                                switch (variable_name)
                                {
                                    case "iobs":
                                        {
                                            u_id = Convert.ToString(record.GetValue(variable));
                                            userID = find_UserId(SURVEY_ID, SURVEY_PERIOD, u_id);
                                            // userID = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "weight":
                                        {
                                            weightage = Convert.ToDecimal(record.GetValue(variable));
                                            break;
                                        }
                                    case "r5":
                                        {
                                            gender = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "r14":
                                        {
                                            maritalStatus = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "r2":
                                        {
                                            location = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "r7":
                                        {
                                            AgeGroup = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "r13":
                                        {
                                            ses = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "rw":
                                        {
                                            period = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "r26_1":
                                        {
                                            cerealpanel = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "r27c":
                                        {
                                            r27c = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "r31c":
                                        {
                                            r31c = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "r19_1":
                                        {
                                            r19_1 = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "r19_2":
                                        {
                                            r19_2 = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "r19_3":
                                        {
                                            r19_3 = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "r19_4":
                                        {
                                            r19_4 = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "r19_5":
                                        {
                                            r19_5 = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "r19_6":
                                        {
                                            r19_6 = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "r19_7":
                                        {
                                            r19_7 = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "r20":
                                        {
                                            r20 = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "r27a":
                                        {
                                            r27a = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "r27b_11":
                                        {
                                            r27b_11 = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "r27b_12":
                                        {
                                            r27b_12 = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "r27b_15":
                                        {
                                            r27b_15 = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "r27b_16":
                                        {
                                            r27b_16 = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "r27b_17":
                                        {
                                            r27b_17 = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "r27b_18":
                                        {
                                            r27b_18 = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "r27b_24":
                                        {
                                            r27b_24 = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "r27b_30":
                                        {
                                            r27b_30 = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "r27b_36":
                                        {
                                            r27b_36 = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "r27b_41":
                                        {
                                            r27b_41 = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "r27b_52":
                                        {
                                            r27b_52 = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "r27b_53":
                                        {
                                            r27b_53 = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "r27b_83":
                                        {
                                            r27b_83 = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "r30a_11":
                                        {
                                            r30a_11 = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "r30a_12":
                                        {
                                            r30a_12 = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "r30a_15":
                                        {
                                            r30a_15 = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "r30a_16":
                                        {
                                            r30a_16 = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "r30a_17":
                                        {
                                            r30a_17 = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "r30a_18":
                                        {
                                            r30a_18 = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "r30a_24":
                                        {
                                            r30a_24 = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "r30a_30":
                                        {
                                            r30a_30 = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "r30a_36":
                                        {
                                            r30a_36 = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "r30a_41":
                                        {
                                            r30a_41 = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "r30a_52":
                                        {
                                            r30a_52 = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "r30a_53":
                                        {
                                            r30a_53 = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "r30a_83":
                                        {
                                            r30a_83 = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "r27d":
                                        {
                                            r27d = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "r27e_11":
                                        {
                                            r27e_11 = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "r27e_12":
                                        {
                                            r27e_12 = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "r27e_15":
                                        {
                                            r27e_15 = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "r27e_16":
                                        {
                                            r27e_16 = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "r27e_17":
                                        {
                                            r27e_17 = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "r27e_18":
                                        {
                                            r27e_18 = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "r27e_24":
                                        {
                                            r27e_24 = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "r27e_30":
                                        {
                                            r27e_30 = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "r27e_36":
                                        {
                                            r27e_36 = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "r27e_41":
                                        {
                                            r27e_41 = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "r27e_52":
                                        {
                                            r27e_52 = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "r27e_53":
                                        {
                                            r27e_53 = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "r27e_83":
                                        {
                                            r27e_83 = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "r30b_11":
                                        {
                                            r30b_11 = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "r30b_12":
                                        {
                                            r30b_12 = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "r30b_15":
                                        {
                                            r30b_15 = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "r30b_16":
                                        {
                                            r30b_16 = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "r30b_17":
                                        {
                                            r30b_17 = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "r30b_18":
                                        {
                                            r30b_18 = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "r30b_24":
                                        {
                                            r30b_24 = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "r30b_30":
                                        {
                                            r30b_30 = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "r30b_36":
                                        {
                                            r30b_36 = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "r30b_41":
                                        {
                                            r30b_41 = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "r30b_52":
                                        {
                                            r30b_52 = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "r30b_53":
                                        {
                                            r30b_53 = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "r30b_83":
                                        {
                                            r30b_83 = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "r31a_11":
                                        {
                                            r31a_11 = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "r31a_12":
                                        {
                                            r31a_12 = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "r31a_15":
                                        {
                                            r31a_15 = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "r31a_16":
                                        {
                                            r31a_16 = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "r31a_17":
                                        {
                                            r31a_17 = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "r31a_18":
                                        {
                                            r31a_18 = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "r31a_24":
                                        {
                                            r31a_24 = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "r31a_30":
                                        {
                                            r31a_30 = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "r31a_36":
                                        {
                                            r31a_36 = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "r31a_41":
                                        {
                                            r31a_41 = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "r31a_52":
                                        {
                                            r31a_52 = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "r31a_53":
                                        {
                                            r31a_53 = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "r31a_83":
                                        {
                                            r31a_83 = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "r31b_11":
                                        {
                                            r31b_11 = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "r31b_12":
                                        {
                                            r31b_12 = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "r31b_15":
                                        {
                                            r31b_15 = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "r31b_16":
                                        {
                                            r31b_16 = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "r31b_17":
                                        {
                                            r31b_17 = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "r31b_18":
                                        {
                                            r31b_18 = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "r31b_24":
                                        {
                                            r31b_24 = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "r31b_30":
                                        {
                                            r31b_30 = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "r31b_36":
                                        {
                                            r31b_36 = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "r31b_41":
                                        {
                                            r31b_41 = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "r31b_52":
                                        {
                                            r31b_52 = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "r31b_53":
                                        {
                                            r31b_53 = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "r31b_83":
                                        {
                                            r31b_83 = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "r24a_1":
                                        {
                                            r24a_1 = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "r24a_2":
                                        {
                                            r24a_2 = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "r24a_3":
                                        {
                                            r24a_3 = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "r24a_4":
                                        {
                                            r24a_4 = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "r24a_5":
                                        {
                                            r24a_5 = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "r24br1_1":
                                        {
                                            r24br1_1 = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "r24br1_2":
                                        {
                                            r24br1_2 = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "r24br1_3":
                                        {
                                            r24br1_3 = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "r24br1_4":
                                        {
                                            r24br1_4 = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "r24br1_5":
                                        {
                                            r24br1_5 = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "r24br1_6":
                                        {
                                            r24br1_6 = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "r24br2_1":
                                        {
                                            r24br2_1 = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "r24br2_2":
                                        {
                                            r24br2_2 = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "r24br2_3":
                                        {
                                            r24br2_3 = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "r24br2_4":
                                        {
                                            r24br2_4 = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "r24br2_5":
                                        {
                                            r24br2_5 = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "r24br2_6":
                                        {
                                            r24br2_6 = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "r24br3_1":
                                        {
                                            r24br3_1 = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "r24br3_2":
                                        {
                                            r24br3_2 = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "r24br3_3":
                                        {
                                            r24br3_3 = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "r24br3_4":
                                        {
                                            r24br3_4 = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "r24br3_5":
                                        {
                                            r24br3_5 = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "r24br3_6":
                                        {
                                            r24br3_6 = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "r24br4_1":
                                        {
                                            r24br4_1 = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }

                                    case "r24br4_2":
                                        {
                                            r24br4_2 = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "r24br4_3":
                                        {
                                            r24br4_3 = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "r24br4_4":
                                        {
                                            r24br4_4 = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "r24br4_5":
                                        {
                                            r24br4_5 = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "r24br4_6":
                                        {
                                            r24br4_6 = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "r24br5_1":
                                        {
                                            r24br5_1 = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "r24br5_2":
                                        {
                                            r24br5_2 = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "r24br5_3":
                                        {
                                            r24br5_3 = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "r24br5_4":
                                        {
                                            r24br5_4 = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "r24br5_5":
                                        {
                                            r24br5_5 = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "r24br5_6":
                                        {
                                            r24br5_6 = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "r27an_1":
                                        {
                                            r27an_1 = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "r27an_2":
                                        {
                                            r27an_2 = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "r27an_10":
                                        {
                                            r27an_10 = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "r27an_12":
                                        {
                                            r27an_12 = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "r27bn_1":
                                        {
                                            r27bn_1 = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "r27bn_2":
                                        {
                                            r27bn_2 = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "r27bn_10":
                                        {
                                            r27bn_10 = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "r27bn_12":
                                        {
                                            r27bn_12 = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "r30an_1":
                                        {
                                            r30an_1 = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "r30an_2":
                                        {
                                            r30an_2 = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "r30an_10":
                                        {
                                            r30an_10 = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "r30an_12":
                                        {
                                            r30an_12 = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "r27dn_1":
                                        {
                                            r27dn_1 = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "r27dn_2":
                                        {
                                            r27dn_2 = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "r27dn_10":
                                        {
                                            r27dn_10 = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "r27dn_12":
                                        {
                                            r27dn_12 = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "r27en_1":
                                        {
                                            r27en_1 = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "r27en_2":
                                        {
                                            r27en_2 = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "r27en_10":
                                        {
                                            r27en_10 = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "r27en_12":
                                        {
                                            r27en_12 = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "r30bn_1":
                                        {
                                            r30bn_1 = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "r30bn_2":
                                        {
                                            r30bn_2 = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "r30bn_10":
                                        {
                                            r30bn_10 = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "r30bn_12":
                                        {
                                            r30bn_12 = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "r27cn_1":
                                        {
                                            r27cn_1 = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "r27cn_2":
                                        {
                                            r27cn_2 = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "r27cn_10":
                                        {
                                            r27cn_10 = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "r27cn_12":
                                        {
                                            r27cn_12 = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "r31cn_1":
                                        {
                                            r31cn_1 = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "r31cn_2":
                                        {
                                            r31cn_2 = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "r31cn_10":
                                        {
                                            r31cn_10 = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "r31cn_12":
                                        {
                                            r31cn_12 = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "r31an_1":
                                        {
                                            r31an_1 = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "r31an_2":
                                        {
                                            r31an_2 = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "r31an_10":
                                        {
                                            r31an_10 = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "r31an_12":
                                        {
                                            r31an_12 = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "r31bn_1":
                                        {
                                            r31bn_1 = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "r31bn_2":
                                        {
                                            r31bn_2 = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "r31bn_10":
                                        {
                                            r31bn_10 = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "r31bn_12":
                                        {
                                            r31bn_12 = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "r33c4_1":
                                        {
                                            r33c4_1 = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "r252r1_2":
                                        {
                                            r33c4_2 = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "r252r6_2":
                                        {
                                            r33c4_4 = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "r252r9_2":
                                        {
                                            r33c4_6 = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "r252r11_2":
                                        {
                                            r33c4_8 = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "r252r8_2":
                                        {
                                            r33c4_9 = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "r252r7_2":
                                        {
                                            r33c4_12 = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "r33c4_13":
                                        {
                                            r33c4_13 = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "r252r4_2":
                                        {
                                            r33c4_14 = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "r33c5_1":
                                        {
                                            r33c5_1 = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "r252r1_4":
                                        {
                                            r33c5_2 = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "r252r6_4":
                                        {
                                            r33c5_4 = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "r252r9_4":
                                        {
                                            r33c5_6 = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "r252r11_4":
                                        {
                                            r33c5_8 = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "r252r8_4":
                                        {
                                            r33c5_9 = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "r252r7_4":
                                        {
                                            r33c5_12 = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "r33c5_13":
                                        {
                                            r33c5_13 = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "r252r4_4":
                                        {
                                            r33c5_14 = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "r33c7_1":
                                        {
                                            r33c7_1 = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "r252r1_6":
                                        {
                                            r33c7_2 = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "r252r6_6":
                                        {
                                            r33c7_4 = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "r252r9_6":
                                        {
                                            r33c7_6 = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "r252r11_6":
                                        {
                                            r33c7_8 = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "r252r8_6":
                                        {
                                            r33c7_9 = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "r252r7_6":
                                        {
                                            r33c7_12 = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "r33c7_13":
                                        {
                                            r33c7_13 = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "r252r4_6":
                                        {
                                            r33c7_14 = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "r33c9_1":
                                        {
                                            r33c9_1 = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "r33c9_2":
                                        {
                                            r33c9_2 = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "r33c9_4":
                                        {
                                            r33c9_4 = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "r33c9_6":
                                        {
                                            r33c9_6 = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "r33c9_8":
                                        {
                                            r33c9_8 = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "r33c9_9":
                                        {
                                            r33c9_9 = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "r33c9_12":
                                        {
                                            r33c9_12 = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "r33c9_13":
                                        {
                                            r33c9_13 = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "r33c9_14":
                                        {
                                            r33c9_14 = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "r33c10_1":
                                        {
                                            r33c10_1 = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "r33c10_2":
                                        {
                                            r33c10_2 = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "r33c10_4":
                                        {
                                            r33c10_4 = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "r33c10_6":
                                        {
                                            r33c10_6 = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "r33c10_8":
                                        {
                                            r33c10_8 = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "r33c10_9":
                                        {
                                            r33c10_9 = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "r33c10_12":
                                        {
                                            r33c10_12 = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "r33c10_13":
                                        {
                                            r33c10_13 = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "r33c10_14":
                                        {
                                            r33c10_14 = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "r27b_89":
                                        {
                                            BrSpontGoW_Chocolate = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "r30a_89":
                                        {
                                            BrAidGoW_Chocolate = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "r27e_89":
                                        {
                                            AdSpontGoW_Chocolate = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "r30b_89":
                                        {
                                            AdAidGoW_Chocolate = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "r31a_89":
                                        {
                                            ConsL3MGoW_Chocolate = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "r31b_89":
                                        {
                                            ConsLMGoW_Chocolate = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "r27b_90":
                                        {
                                            BrSpontGoW_Vanilla = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "r30a_90":
                                        {
                                            BrAidGoW_Vanilla = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "r27e_90":
                                        {
                                            AdSpontGoW_Vanilla = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "r30b_90":
                                        {
                                            AdAidGoW_Vanilla = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "r31a_90":
                                        {
                                            ConsL3MGoW_Vanilla = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "r31b_90":
                                        {
                                            ConsLMGoW_Vanilla = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "r27an_22":
                                        {
                                            BrTom_GoWell_NET = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "r27bn_22":
                                        {
                                            BrSpont_GoWell_NET = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "r30an_22":
                                        {
                                            BrAided_GoWell_NET = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "r27dn_22":
                                        {
                                            AdTom_GoWell_NET = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "r27en_22":
                                        {
                                            AdSpont_GoWell_NET = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "r30bn_22":
                                        {
                                            AdAided_GoWell_NET = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "r27cn_22":
                                        {
                                            Fav_GoWell_NET = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "r31cn_22":
                                        {
                                            Bumo_GoWell_NET = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "r31an_22":
                                        {
                                            ConsL3M_GoWell_NET = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "r31bn_22":
                                        {
                                            ConsLM_GoWell_NET = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "r137a_11":
                                        {
                                            r137a_11 = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "r137a_12":
                                        {
                                            r137a_12 = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "r137a_15":
                                        {
                                            r137a_15 = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "r137a_16":
                                        {
                                            r137a_16 = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "r137a_17":
                                        {
                                            r137a_17 = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "r137a_18":
                                        {
                                            r137a_18 = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "r137a_24":
                                        {
                                            r137a_24 = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "r137a_30":
                                        {
                                            r137a_30 = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "r137a_36":
                                        {
                                            r137a_36 = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "r137a_41":
                                        {
                                            r137a_41 = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "r137a_52":
                                        {
                                            r137a_52 = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "r137a_53":
                                        {
                                            r137a_53 = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "r137a_83":
                                        {
                                            r137a_83 = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "r137a_90":
                                        {
                                            ConsP1WGoW_Vanilla = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "r137a_89":
                                        {
                                            ConsP1WGoW_Chocolate = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "r291_11":
                                        {
                                            r291_11 = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "r291_12":
                                        {
                                            r291_12 = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "r291_15":
                                        {
                                            r291_15 = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "r291_16":
                                        {
                                            r291_16 = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "r291_17":
                                        {
                                            r291_17 = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "r291_18":
                                        {
                                            r291_18 = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "r291_24":
                                        {
                                            r291_24 = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "r291_30":
                                        {
                                            r291_30 = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "r291_36":
                                        {
                                            r291_36 = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "r291_41":
                                        {
                                            r291_41 = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "r291_52":
                                        {
                                            r291_52 = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "r291_53":
                                        {
                                            r291_53 = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "r291_83":
                                        {
                                            r291_83 = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "r291_90":
                                        {
                                            ConsP1DGoW_Vanilla = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "r291_89":
                                        {
                                            ConsP1DGoW_Chocolate = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "r137an_2":
                                        {
                                            ConsP1W_Energen = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "r137an_10":
                                        {
                                            r137an_10 = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "r137an_12":
                                        {
                                            r137an_12 = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "r137an_1":
                                        {
                                            r137an_1 = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "r137an_22":
                                        {
                                            ConsP1W_GoWell_NET = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                   case  "r291n_2":
                                        {
                                            ConsP1D_Energen = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "r291n_10":
                                        {
                                            r291n_10 = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "r291n_12":
                                        {
                                            r291n_12 = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "r291n_1":
                                        {
                                            r291n_1 = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "r291n_22":
                                        {
                                            ConsP1D_GoWell_NET = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }

                                }
                            }
                        }
                    }
                    if (u_id != null && weightage != 0)
                    {
                        // Console.Write(userID + " " + userEmail + " " + firstName + " " + lastName + " " + UserStatus + " " + gender + " " + maritalStatus + " " + education + " " + race + " " + religion + " " + postCode + " " + country + " " + city + " " + subDistrict + " " + village + " " + incomeRange + " " + industryName + " " + occupation + " " + SURVEY_ID + " " + favouriteBrand + " " + bumo + " " + AdTom + " " + BrTom);
                        iobj.insert_Dashboard_values(userID, userEmail, firstName, lastName, UserStatus, gender, maritalStatus, education, race, religion, postCode, country, city, subDistrict, village, incomeRange, industryName, occupation, SURVEY_ID, weightage, SURVEY_PERIOD, location, AgeGroup, ses, period, cerealpanel, r27c, r31c, r19_1, r19_2, r19_3, r19_4, r19_5, r19_6, r19_7, r20, r27a, r27b_11, r27b_12, r27b_15, r27b_16, r27b_17, r27b_18, r27b_24, r27b_30, r27b_36, r27b_41, r27b_52, r27b_53, r27b_83, r30a_11, r30a_12, r30a_15, r30a_16, r30a_17, r30a_18, r30a_24, r30a_30, r30a_36, r30a_41, r30a_52, r30a_53, r30a_83, r27d, r27e_11, r27e_12, r27e_15, r27e_16, r27e_17, r27e_18, r27e_24, r27e_30, r27e_36, r27e_41, r27e_52, r27e_53, r27e_83, r30b_11, r30b_12, r30b_15, r30b_16, r30b_17, r30b_18, r30b_24, r30b_30, r30b_36, r30b_41, r30b_52, r30b_53, r30b_83, r31a_11, r31a_12, r31a_15, r31a_16, r31a_17, r31a_18, r31a_24, r31a_30, r31a_36, r31a_41, r31a_52, r31a_53, r31a_83, r31b_11, r31b_12, r31b_15, r31b_16, r31b_17, r31b_18, r31b_24, r31b_30, r31b_36, r31b_41, r31b_52, r31b_53, r31b_83, r24a_1, r24a_2, r24a_3, r24a_4, r24a_5, r24br1_1, r24br1_2, r24br1_3, r24br1_4, r24br1_5, r24br1_6, r24br2_1, r24br2_2, r24br2_3, r24br2_4, r24br2_5, r24br2_6, r24br3_1, r24br3_2, r24br3_3, r24br3_4, r24br3_5, r24br3_6, r24br4_1, r24br4_2, r24br4_3, r24br4_4, r24br4_5, r24br4_6, r24br5_1, r24br5_2, r24br5_3, r24br5_4, r24br5_5, r24br5_6, r27an_1, r27an_2, r27an_10, r27an_12, r27bn_1, r27bn_2, r27bn_10, r27bn_12, r30an_1, r30an_2, r30an_10, r30an_12, r27dn_1, r27dn_2, r27dn_10, r27dn_12, r27en_1, r27en_2, r27en_10, r27en_12, r30bn_1, r30bn_2, r30bn_10, r30bn_12, r27cn_1, r27cn_2, r27cn_10, r27cn_12, r31cn_1, r31cn_2, r31cn_10, r31cn_12, r31an_1, r31an_2, r31an_10, r31an_12, r31bn_1, r31bn_2, r31bn_10, r31bn_12, r33c4_1, r33c4_2, r33c4_4, r33c4_6, r33c4_8, r33c4_9, r33c4_12, r33c4_13, r33c4_14, r33c5_1, r33c5_2, r33c5_4, r33c5_6, r33c5_8, r33c5_9, r33c5_12, r33c5_13, r33c5_14, r33c7_1, r33c7_2, r33c7_4, r33c7_6, r33c7_8, r33c7_9, r33c7_12, r33c7_13, r33c7_14, r33c9_1, r33c9_2, r33c9_4, r33c9_6, r33c9_8, r33c9_9, r33c9_12, r33c9_13, r33c9_14, r33c10_1, r33c10_2, r33c10_4, r33c10_6, r33c10_8, r33c10_9, r33c10_12, r33c10_13, r33c10_14, BrSpontGoW_Chocolate, BrAidGoW_Chocolate, AdSpontGoW_Chocolate, AdAidGoW_Chocolate, ConsL3MGoW_Chocolate, ConsLMGoW_Chocolate, BrSpontGoW_Vanilla, BrAidGoW_Vanilla, AdSpontGoW_Vanilla, AdAidGoW_Vanilla, ConsL3MGoW_Vanilla, ConsLMGoW_Vanilla, BrTom_GoWell_NET, BrSpont_GoWell_NET, BrAided_GoWell_NET, AdTom_GoWell_NET, AdSpont_GoWell_NET, AdAided_GoWell_NET, Fav_GoWell_NET, Bumo_GoWell_NET,ConsL3M_GoWell_NET, ConsLM_GoWell_NET, r137a_11, r137a_12, r137a_15, r137a_16, r137a_17, r137a_18, r137a_24, r137a_30, r137a_36, r137a_41, r137a_52, r137a_53, r137a_83, ConsP1WGoW_Vanilla, ConsP1WGoW_Chocolate, r291_11, r291_12, r291_15, r291_16, r291_17, r291_18, r291_24, r291_30, r291_36, r291_41, r291_52, r291_53, r291_83, ConsP1DGoW_Vanilla, ConsP1DGoW_Chocolate, ConsP1W_Energen, r137an_10, r137an_12, r137an_1, ConsP1W_GoWell_NET, ConsP1D_Energen, r291n_10, r291n_12, r291n_1, ConsP1D_GoWell_NET);
                        //iobj.insert_Dashboard_values_BI(userID, SURVEY_ID, period, r33c4_1, r33c4_2, r33c4_4, r33c4_6, r33c4_8, r33c4_9, r33c4_12, r33c4_13, r33c4_14, r33c5_1, r33c5_2, r33c5_4, r33c5_6, r33c5_8, r33c5_9, r33c5_12, r33c5_13, r33c5_14, r33c7_1, r33c7_2, r33c7_4, r33c7_6, r33c7_8, r33c7_9, r33c7_12, r33c7_13, r33c7_14, r33c9_1, r33c9_2, r33c9_4, r33c9_6, r33c9_8, r33c9_9, r33c9_12, r33c9_13, r33c9_14, r33c10_1, r33c10_2, r33c10_4, r33c10_6, r33c10_8, r33c10_9, r33c10_12, r33c10_13, r33c10_14);
                       
                        
                    }
                }
            }
        }

        private static string find_UserId(int SURVEY_ID, string SURVEY_PERIOD, string u_id)
        {
            string sum = "";
            string[] date = SURVEY_PERIOD.Split('-');
            foreach (string d in date)
            {
                sum = sum + d;

            }
            return u_id + SURVEY_ID + sum;
        }
    }
    class Insertion_M2cerls
    {
        SqlConnection connection = new SqlConnection("Data Source=52.74.59.117;Initial Catalog=ClueboxMobile;Persist Security Info=True;User ID=sa;Password=ClueBox123*;");
        internal void insert_Dashboard_variable_values(string VARIABLE_NAME, string VARIABLE_NAME_SUB_NAME, string VARIABLE_ID, string VARIABLE_VALUE, string VARIABLE_NAME_QUESTION, int SURVEY_ID, string country, string BASE_VARIABLE_NAME, string SURVEY_PERIOD)
        {
            SqlCommand cmd = new SqlCommand("INSERT INTO DashboardSPS_Variable_Values (VARIABLE_NAME,VARIABLE_NAME_SUB_NAME,VARIABLE_ID,VARIABLE_VALUE,VARIABLE_NAME_QUESTION,SURVEY_ID,SURVEY_COUNTRY,BASE_VARIABLE_NAME,SURVEY_PERIOD) " + "VALUES('" + VARIABLE_NAME + "','" + VARIABLE_NAME_SUB_NAME + "','" + VARIABLE_ID + "','" + VARIABLE_VALUE + "','" + VARIABLE_NAME_QUESTION + "','" + SURVEY_ID + "','" + country + "','" + BASE_VARIABLE_NAME + "','" + SURVEY_PERIOD + "')", connection);
            try
            {

                connection.Open();
                cmd.ExecuteNonQuery();
                Console.WriteLine("Dashboard variable values inserted successfully");

                connection.Close();



            }
            catch (Exception)
            {

                Console.WriteLine("Exception occured");
                Console.ReadLine();
            }
        }

        internal void insert_Dashboard_values(string userID, string userEmail, string firstName, string lastName, string UserStatus, string gender, string maritalStatus, string education, string race, string religion, string postCode, string country, string city, string subDistrict, string village, string incomeRange, string industryName, string occupation, int SURVEY_ID, decimal weightage, string SURVEY_PERIOD, string location, string AgeGroup, string ses, string period, string cerealpanel, string r27c, string r31c, string r19_1, string r19_2, string r19_3, string r19_4, string r19_5, string r19_6, string r19_7, string r20, string r27a, string r27b_11, string r27b_12, string r27b_15, string r27b_16, string r27b_17, string r27b_18, string r27b_24, string r27b_30, string r27b_36, string r27b_41, string r27b_52, string r27b_53, string r27b_83, string r30a_11, string r30a_12, string r30a_15, string r30a_16, string r30a_17, string r30a_18, string r30a_24, string r30a_30, string r30a_36, string r30a_41, string r30a_52, string r30a_53, string r30a_83, string r27d, string r27e_11, string r27e_12, string r27e_15, string r27e_16, string r27e_17, string r27e_18, string r27e_24, string r27e_30, string r27e_36, string r27e_41, string r27e_52, string r27e_53, string r27e_83, string r30b_11, string r30b_12, string r30b_15, string r30b_16, string r30b_17, string r30b_18, string r30b_24, string r30b_30, string r30b_36, string r30b_41, string r30b_52, string r30b_53, string r30b_83, string r31a_11, string r31a_12, string r31a_15, string r31a_16, string r31a_17, string r31a_18, string r31a_24, string r31a_30, string r31a_36, string r31a_41, string r31a_52, string r31a_53, string r31a_83, string r31b_11, string r31b_12, string r31b_15, string r31b_16, string r31b_17, string r31b_18, string r31b_24, string r31b_30, string r31b_36, string r31b_41, string r31b_52, string r31b_53, string r31b_83, string r24a_1, string r24a_2, string r24a_3, string r24a_4, string r24a_5, string r24br1_1, string r24br1_2, string r24br1_3, string r24br1_4, string r24br1_5, string r24br1_6, string r24br2_1, string r24br2_2, string r24br2_3, string r24br2_4, string r24br2_5, string r24br2_6, string r24br3_1, string r24br3_2, string r24br3_3, string r24br3_4, string r24br3_5, string r24br3_6, string r24br4_1, string r24br4_2, string r24br4_3, string r24br4_4, string r24br4_5, string r24br4_6, string r24br5_1, string r24br5_2, string r24br5_3, string r24br5_4, string r24br5_5, string r24br5_6, string r27an_1, string r27an_2, string r27an_10, string r27an_12, string r27bn_1, string r27bn_2, string r27bn_10, string r27bn_12, string r30an_1, string r30an_2, string r30an_10, string r30an_12, string r27dn_1, string r27dn_2, string r27dn_10, string r27dn_12, string r27en_1, string r27en_2, string r27en_10, string r27en_12, string r30bn_1, string r30bn_2, string r30bn_10, string r30bn_12, string r27cn_1, string r27cn_2, string r27cn_10, string r27cn_12, string r31cn_1, string r31cn_2, string r31cn_10, string r31cn_12, string r31an_1, string r31an_2, string r31an_10, string r31an_12, string r31bn_1, string r31bn_2, string r31bn_10, string r31bn_12, string r33c4_1, string r33c4_2, string r33c4_4, string r33c4_6, string r33c4_8, string r33c4_9, string r33c4_12, string r33c4_13, string r33c4_14, string r33c5_1, string r33c5_2, string r33c5_4, string r33c5_6, string r33c5_8, string r33c5_9, string r33c5_12, string r33c5_13, string r33c5_14, string r33c7_1, string r33c7_2, string r33c7_4, string r33c7_6, string r33c7_8, string r33c7_9, string r33c7_12, string r33c7_13, string r33c7_14, string r33c9_1, string r33c9_2, string r33c9_4, string r33c9_6, string r33c9_8, string r33c9_9, string r33c9_12, string r33c9_13, string r33c9_14, string r33c10_1, string r33c10_2, string r33c10_4, string r33c10_6, string r33c10_8, string r33c10_9, string r33c10_12, string r33c10_13, string r33c10_14, string BrSpontGoW_Chocolate, string BrAidGoW_Chocolate, string AdSpontGoW_Chocolate, string AdAidGoW_Chocolate, string ConsL3MGoW_Chocolate, string ConsLMGoW_Chocolate, string BrSpontGoW_Vanilla, string BrAidGoW_Vanilla, string AdSpontGoW_Vanilla, string AdAidGoW_Vanilla, string ConsL3MGoW_Vanilla, string ConsLMGoW_Vanilla, string BrTom_GoWell_NET, string BrSpont_GoWell_NET, string BrAided_GoWell_NET, string AdTom_GoWell_NET, string AdSpont_GoWell_NET, string AdAided_GoWell_NET, string Fav_GoWell_NET, string Bumo_GoWell_NET, string ConsL3M_GoWell_NET, string ConsLM_GoWell_NET, string r137a_11, string r137a_12, string r137a_15, string r137a_16, string r137a_17, string r137a_18, string r137a_24, string r137a_30, string r137a_36, string r137a_41, string r137a_52, string r137a_53, string r137a_83, string ConsP1WGoW_Vanilla, string ConsP1WGoW_Chocolate, string r291_11, string r291_12, string r291_15, string r291_16, string r291_17, string r291_18, string r291_24, string r291_30, string r291_36, string r291_41, string r291_52, string r291_53, string r291_83, string ConsP1DGoW_Vanilla, string ConsP1DGoW_Chocolate, string ConsP1W_Energen, string r137an_10, string r137an_12, string r137an_1, string ConsP1W_GoWell_NET, string ConsP1D_Energen, string r291n_10, string r291n_12, string r291n_1, string ConsP1D_GoWell_NET)
        {
            int i;
            connection.Open();
            //SqlConnection connection = new SqlConnection("Data Source=52.74.59.117;Initial Catalog=ClueboxMobile;Persist Security Info=True;User ID=sa;Password=ClueBox123*;");
              //SqlCommand cmd = new SqlCommand("INSERT INTO DashboardFlatTabJava_m2cereal_temp (UserID,UserEmail,FirstName,LastName,UserStatus,Gender,MaritalStatus,Education,Race,Religion,PostCode,Country,City,SubDistrict,Village,IncomeRange,IndustryName,Occupation,SurveyID,AttendedOn,Weight,SurveyPeriod,Location,AgeGroup,Ses,Period,cerealpanel,FAVORITE_BRAND,BUMO,r19_1,r19_2,r19_3,r19_4,r19_5,r19_6,r19_7,r20,BrTom,BrSpontEnergen_Oat_berry,BrSpontEnergen_Oat_banana,BrSpontEnergen_Susu_Chocolate,BrSpontEnergen_Susu_Jahe,BrSpontEnergen_Kacang_Hijau,BrSpontEnergen_Susu_Vanilla,BrSpontKelloggs_Corn_Flakes,BrSpontMilo,BrSpontNestle_Koko_Krunch,BrSpontNestle_Honey_Star,BrSpontQuaker_Biru,BrSpontQuaker_Merah,BrSpontEnergen_Sereal_and_Susu_Jagung,BrAidEnergen_Oat_berry,BrAidEnergen_Oat_banana,BrAidEnergen_Susu_Chocolate,BrAidEnergen_Susu_Jahe,BrAidEnergen_Kacang_Hijau,BrAidEnergen_Susu_Vanilla,BrAidKelloggs_Corn_Flakes,BrAidMilo,BrAidNestle_Koko_Krunch,BrAidNestle_Honey_Star,BrAidQuaker_Biru,BrAidQuaker_Merah,BrAidEnergen_Sereal_and_Susu_Jagung,AdTom,AdSpontEnergen_Oat_berry,AdSpontEnergen_Oat_banana,AdSpontEnergen_Susu_Chocolate,AdSpontEnergen_Susu_Jahe,AdSpontEnergen_Kacang_Hijau,AdSpontEnergen_Susu_Vanilla,AdSpontKelloggs_Corn_Flakes,AdSpontMilo,AdSpontNestle_Koko_Krunch,AdSpontNestle_Honey_Star,AdSpontQuaker_Biru,AdSpontQuaker_Merah,AdSpontEnergen_Sereal_and_Susu_Jagung,AdAidEnergen_Oat_berry,AdAidEnergen_Oat_banana,AdAidEnergen_Susu_Chocolate,AdAidEnergen_Susu_Jahe,AdAidEnergen_Kacang_Hijau,AdAidEnergen_Susu_Vanilla,AdAidKelloggs_Corn_Flakes,AdAidMilo,AdAidNestle_Koko_Krunch,AdAidNestle_Honey_Star,AdAidQuaker_Biru,AdAidQuaker_Merah,AdAidEnergen_Sereal_and_Susu_Jagung,ConsL3MEnergen_Oat_berry,ConsL3MEnergen_Oat_banana,ConsL3MEnergen_Susu_Chocolate,ConsL3MEnergen_Susu_Jahe,ConsL3MEnergen_Kacang_Hijau,ConsL3MEnergen_Susu_Vanilla,ConsL3MKelloggs_Corn_Flakes,ConsL3MMilo,ConsL3MNestle_Koko_Krunch,ConsL3MNestle_Honey_Star,ConsL3MQuaker_Biru,ConsL3MQuaker_Merah,ConsL3MEnergen_Sereal_and_Susu_Jagung,ConsLMEnergen_Oat_berry,ConsLMEnergen_Oat_banana,ConsLMEnergen_Susu_Chocolate,ConsLMEnergen_Susu_Jahe,ConsLMEnergen_Kacang_Hijau,ConsLMEnergen_Susu_Vanilla,ConsLMKelloggs_Corn_Flakes,ConsLMMilo,ConsLMNestle_Koko_Krunch,ConsLMNestle_Honey_Star,ConsLMQuaker_Biru,ConsLMQuaker_Merah,ConsLMEnergen_Sereal_and_Susu_Jagung,r24a_1,r24a_2,r24a_3,r24a_4,r24a_5,r24br1_1,r24br1_2,r24br1_3,r24br1_4,r24br1_5,r24br1_6,r24br2_1,r24br2_2,r24br2_3,r24br2_4,r24br2_5,r24br2_6,r24br3_1,r24br3_2,r24br3_3,r24br3_4,r24br3_5,r24br3_6,r24br4_1,r24br4_2,r24br4_3,r24br4_4,r24br4_5,r24br4_6,r24br5_1,r24br5_2,r24br5_3,r24br5_4,r24br5_5,r24br5_6,r27an_1,BrTom_Energen,r27an_10,r27an_12,r27bn_1,BrSpont_Energen,r27bn_10,r27bn_12,r30an_1,BrAided_Energen,r30an_10,r30an_12,r27dn_1,AdTom_Energen,r27dn_10,r27dn_12,r27en_1,AdSpont_Energen,r27en_10,r27en_12,r30bn_1,AdAided_Energen,r30bn_10,r30bn_12,r27cn_1,Fav_Energen,r27cn_10,r27cn_12,r31cn_1,Bumo_Energen,r31cn_10,r31cn_12,r31an_1,ConsL3M_Energen,r31an_10,r31an_12,r31bn_1,ConsLM_Energen,r31bn_10,r31bn_12,BrTom_BK,AdTom_BK,FAVORITEBRAND_BK,BUMO_BK,r33c4_1,r33c4_2,r33c4_4,r33c4_6,r33c4_8,r33c4_9,r33c4_12,r33c4_13,r33c4_14,r33c5_1,r33c5_2,r33c5_4,r33c5_6,r33c5_8,r33c5_9,r33c5_12,r33c5_13,r33c5_14,r33c7_1,r33c7_2,r33c7_4,r33c7_6,r33c7_8,r33c7_9,r33c7_12,r33c7_13,r33c7_14,r33c9_1,r33c9_2,r33c9_4,r33c9_6,r33c9_8,r33c9_9,r33c9_12,r33c9_13,r33c9_14,r33c10_1,r33c10_2,r33c10_4,r33c10_6,r33c10_8,r33c10_9,r33c10_12,r33c10_13,r33c10_14,BrSpontGoW_Chocolate,BrAidGoW_Chocolate,AdSpontGoW_Chocolate,AdAidGoW_Chocolate,ConsL3MGoW_Chocolate,ConsLMGoW_Chocolate,BrSpontGoW_Vanilla,BrAidGoW_Vanilla,AdSpontGoW_Vanilla,AdAidGoW_Vanilla,ConsL3MGoW_Vanilla,ConsLMGoW_Vanilla,BrTom_GoWell_NET,BrSpont_GoWell_NET,BrAided_GoWell_NET,AdTom_GoWell_NET,AdSpont_GoWell_NET,AdAided_GoWell_NET,Fav_GoWell_NET,Bumo_GoWell_NET,ConsL3M_GoWell_NET,ConsLM_GoWell_NET,ConsP1WEnergen_Oat_berry,ConsP1WEnergen_Oat_banana,ConsP1WEnergen_Susu_Chocolate,ConsP1WEnergen_Susu_Jahe,ConsP1WEnergen_Kacang_Hijau,ConsP1WEnergen_Susu_Vanilla,ConsP1WKelloggs_Corn_Flakes,ConsP1WMilo,ConsP1WNestle_Koko_Krunch,ConsP1WNestle_Honey_Star,ConsP1WQuaker_Biru,ConsP1WQuaker_Merah,ConsP1WEnergen_Sereal_and_Susu_Jagung,ConsP1WGoW_Vanilla,ConsP1WGoW_Chocolate,ConsP1DEnergen_Oat_berry,ConsP1DEnergen_Oat_banana,ConsP1DEnergen_Susu_Chocolate,ConsP1DEnergen_Susu_Jahe,ConsP1DEnergen_Kacang_Hijau,ConsP1DEnergen_Susu_Vanilla,ConsP1DKelloggs_Corn_Flakes,ConsP1DMilo,ConsP1DNestle_Koko_Krunch,ConsP1DNestle_Honey_Star,ConsP1DQuaker_Biru,ConsP1DQuaker_Merah,ConsP1DEnergen_Sereal_and_Susu_Jagung,ConsP1DGoW_Vanilla,ConsP1DGoW_Chocolate,ConsP1W_Energen,r137an_10,r137an_12,r137an_1,ConsP1W_GoWell_NET,ConsP1D_Energen,r291n_10,r291n_12,r291n_1,ConsP1D_GoWell_NET) " + "VALUES('" + userID + "','" + userEmail + "','" + firstName + "','" + lastName + "','" + UserStatus + "','" + gender + "','" + maritalStatus + "','" + education + "','" + race + "','" + religion + "','" + postCode + "','" + country + "','" + city + "','" + subDistrict + "','" + village + "','" + incomeRange + "','" + industryName + "','" + occupation + "','" + SURVEY_ID + "','" + SURVEY_PERIOD + "','" + weightage + "','" + SURVEY_PERIOD + "','" + location + "','" + AgeGroup + "','" + ses + "','" + period + "','" + cerealpanel + "','" + r27c + "','" + r31c + "','" + r19_1 + "','" + r19_2 + "','" + r19_3 + "','" + r19_4 + "','" + r19_5 + "','" + r19_6 + "','" + r19_7 + "','" + r20 + "','" + r27a + "','" + r27b_11 + "','" + r27b_12 + "','" + r27b_15 + "','" + r27b_16 + "','" + r27b_17 + "','" + r27b_18 + "','" + r27b_24 + "','" + r27b_30 + "','" + r27b_36 + "','" + r27b_41 + "','" + r27b_52 + "','" + r27b_53 + "','" + r27b_83 + "','" + r30a_11 + "','" + r30a_12 + "','" + r30a_15 + "','" + r30a_16 + "','" + r30a_17 + "','" + r30a_18 + "','" + r30a_24 + "','" + r30a_30 + "','" + r30a_36 + "','" + r30a_41 + "','" + r30a_52 + "','" + r30a_53 + "','" + r30a_83 + "','" + r27d + "','" + r27e_11 + "','" + r27e_12 + "','" + r27e_15 + "','" + r27e_16 + "','" + r27e_17 + "','" + r27e_18 + "','" + r27e_24 + "','" + r27e_30 + "','" + r27e_36 + "','" + r27e_41 + "','" + r27e_52 + "','" + r27e_53 + "','" + r27e_83 + "','" + r30b_11 + "','" + r30b_12 + "','" + r30b_15 + "','" + r30b_16 + "','" + r30b_17 + "','" + r30b_18 + "','" + r30b_24 + "','" + r30b_30 + "','" + r30b_36 + "','" + r30b_41 + "','" + r30b_52 + "','" + r30b_53 + "','" + r30b_83 + "','" + r31a_11 + "','" + r31a_12 + "','" + r31a_15 + "','" + r31a_16 + "','" + r31a_17 + "','" + r31a_18 + "','" + r31a_24 + "','" + r31a_30 + "','" + r31a_36 + "','" + r31a_41 + "','" + r31a_52 + "','" + r31a_53 + "','" + r31a_83 + "','" + r31b_11 + "','" + r31b_12 + "','" + r31b_15 + "','" + r31b_16 + "','" + r31b_17 + "','" + r31b_18 + "','" + r31b_24 + "','" + r31b_30 + "','" + r31b_36 + "','" + r31b_41 + "','" + r31b_52 + "','" + r31b_53 + "','" + r31b_83 + "','" + r24a_1 + "','" + r24a_2 + "','" + r24a_3 + "','" + r24a_4 + "','" + r24a_5 + "','" + r24br1_1 + "','" + r24br1_2 + "','" + r24br1_3 + "','" + r24br1_4 + "','" + r24br1_5 + "','" + r24br1_6 + "','" + r24br2_1 + "','" + r24br2_2 + "','" + r24br2_3 + "','" + r24br2_4 + "','" + r24br2_5 + "','" + r24br2_6 + "','" + r24br3_1 + "','" + r24br3_2 + "','" + r24br3_3 + "','" + r24br3_4 + "','" + r24br3_5 + "','" + r24br3_6 + "','" + r24br4_1 + "','" + r24br4_2 + "','" + r24br4_3 + "','" + r24br4_4 + "','" + r24br4_5 + "','" + r24br4_6 + "','" + r24br5_1 + "','" + r24br5_2 + "','" + r24br5_3 + "','" + r24br5_4 + "','" + r24br5_5 + "','" + r24br5_6 + "','" + r27an_1 + "','" + r27an_2 + "','" + r27an_10 + "','" + r27an_12 + "','" + r27bn_1 + "','" + r27bn_2 + "','" + r27bn_10 + "','" + r27bn_12 + "','" + r30an_1 + "','" + r30an_2 + "','" + r30an_10 + "','" + r30an_12 + "','" + r27dn_1 + "','" + r27dn_2 + "','" + r27dn_10 + "','" + r27dn_12 + "','" + r27en_1 + "','" + r27en_2 + "','" + r27en_10 + "','" + r27en_12 + "','" + r30bn_1 + "','" + r30bn_2 + "','" + r30bn_10 + "','" + r30bn_12 + "','" + r27cn_1 + "','" + r27cn_2 + "','" + r27cn_10 + "','" + r27cn_12 + "','" + r31cn_1 + "','" + r31cn_2 + "','" + r31cn_10 + "','" + r31cn_12 + "','" + r31an_1 + "','" + r31an_2 + "','" + r31an_10 + "','" + r31an_12 + "','" + r31bn_1 + "','" + r31bn_2 + "','" + r31bn_10 + "','" + r31bn_12 + "','" + r27a + "','" + r27d + "','" + r27c + "','" + r31c + "','" + r33c4_1 + "','" + r33c4_2 + "','" + r33c4_4 + "','" + r33c4_6 + "','" + r33c4_8 + "','" + r33c4_9 + "','" + r33c4_12 + "','" + r33c4_13 + "','" + r33c4_14 + "','" + r33c5_1 + "','" + r33c5_2 + "','" + r33c5_4 + "','" + r33c5_6 + "','" + r33c5_8 + "','" + r33c5_9 + "','" + r33c5_12 + "','" + r33c5_13 + "','" + r33c5_14 + "','" + r33c7_1 + "','" + r33c7_2 + "','" + r33c7_4 + "','" + r33c7_6 + "','" + r33c7_8 + "','" + r33c7_9 + "','" + r33c7_12 + "','" + r33c7_13 + "','" + r33c7_14 + "','" + r33c9_1 + "','" + r33c9_2 + "','" + r33c9_4 + "','" + r33c9_6 + "','" + r33c9_8 + "','" + r33c9_9 + "','" + r33c9_12 + "','" + r33c9_13 + "','" + r33c9_14 + "','" + r33c10_1 + "','" + r33c10_2 + "','" + r33c10_4 + "','" + r33c10_6 + "','" + r33c10_8 + "','" + r33c10_9 + "','" + r33c10_12 + "','" + r33c10_13 + "','" + r33c10_14 + "','" + BrSpontGoW_Chocolate + "','" + BrAidGoW_Chocolate + "','" + AdSpontGoW_Chocolate + "','" + AdAidGoW_Chocolate + "','" + ConsL3MGoW_Chocolate + "','" + ConsLMGoW_Chocolate + "','" + BrSpontGoW_Vanilla + "','" + BrAidGoW_Vanilla + "','" + AdSpontGoW_Vanilla + "','" + AdAidGoW_Vanilla + "','" + ConsL3MGoW_Vanilla + "','" + ConsLMGoW_Vanilla + "','" + BrTom_GoWell_NET + "','" + BrSpont_GoWell_NET + "','" + BrAided_GoWell_NET + "','" + AdTom_GoWell_NET + "','" + AdSpont_GoWell_NET + "','" + AdAided_GoWell_NET + "','" + Fav_GoWell_NET + "','" + Bumo_GoWell_NET + "','" + ConsL3M_GoWell_NET + "','" + ConsLM_GoWell_NET + "' ,'" + r137a_11 + "','" + r137a_12 + "','" + r137a_15 + "','" + r137a_16 + "','" + r137a_17 + "','" + r137a_18 + "','" + r137a_24 + "','" + r137a_30 + "','" + r137a_36 + "','" + r137a_41 + "','" + r137a_52 + "','" + r137a_53 + "','" + r137a_83 + "','" + ConsP1WGoW_Vanilla + "','" + ConsP1WGoW_Chocolate + "','" + r291_11 + "','" + r291_12 + "','" + r291_15 + "','" + r291_16 + "','" + r291_17 + "','" + r291_18 + "','" + r291_24 + "','" + r291_30 + "','" + r291_36 + "','" + r291_41 + "','" + r291_52 + "','" + r291_53 + "','" + r291_83 + "','" + ConsP1DGoW_Vanilla + "','" + ConsP1DGoW_Chocolate + "','" + ConsP1W_Energen + "','" + r137an_10 + "','" + r137an_12 + "','" + r137an_1 + "','" + ConsP1W_GoWell_NET + "','" + ConsP1D_Energen + "','" + r291n_10 + "','" + r291n_12 + "','" + r291n_1 + "','" + ConsP1D_GoWell_NET + "')", connection);
            SqlCommand cmd = new SqlCommand("INSERT INTO DashboardFlatTabJava_m2cereal_temp (UserID,UserEmail,FirstName,LastName,UserStatus,Gender,MaritalStatus,Education,Race,Religion,PostCode,Country,City,SubDistrict,Village,IncomeRange,IndustryName,Occupation,SurveyID,AttendedOn,Weight,SurveyPeriod,Location,AgeGroup,Ses,Period,cerealpanel,FAVORITE_BRAND,BUMO,6am_to_9am,9am_to_12pm,12pm_to_3pm,3pm_to_6pm,6pm_to_9pm,9pm_to_12am,12am_to_6am,Length_TV_viewing,BrTom,BrSpontEnergen_Oat_berry,BrSpontEnergen_Oat_banana,BrSpontEnergen_Susu_Chocolate,BrSpontEnergen_Susu_Jahe,BrSpontEnergen_Kacang_Hijau,BrSpontEnergen_Susu_Vanilla,BrSpontKelloggs_Corn_Flakes,BrSpontMilo,BrSpontNestle_Koko_Krunch,BrSpontNestle_Honey_Star,BrSpontQuaker_Biru,BrSpontQuaker_Merah,BrSpontEnergen_Sereal_and_Susu_Jagung,BrAidEnergen_Oat_berry,BrAidEnergen_Oat_banana,BrAidEnergen_Susu_Chocolate,BrAidEnergen_Susu_Jahe,BrAidEnergen_Kacang_Hijau,BrAidEnergen_Susu_Vanilla,BrAidKelloggs_Corn_Flakes,BrAidMilo,BrAidNestle_Koko_Krunch,BrAidNestle_Honey_Star,BrAidQuaker_Biru,BrAidQuaker_Merah,BrAidEnergen_Sereal_and_Susu_Jagung,AdTom,AdSpontEnergen_Oat_berry,AdSpontEnergen_Oat_banana,AdSpontEnergen_Susu_Chocolate,AdSpontEnergen_Susu_Jahe,AdSpontEnergen_Kacang_Hijau,AdSpontEnergen_Susu_Vanilla,AdSpontKelloggs_Corn_Flakes,AdSpontMilo,AdSpontNestle_Koko_Krunch,AdSpontNestle_Honey_Star,AdSpontQuaker_Biru,AdSpontQuaker_Merah,AdSpontEnergen_Sereal_and_Susu_Jagung,AdAidEnergen_Oat_berry,AdAidEnergen_Oat_banana,AdAidEnergen_Susu_Chocolate,AdAidEnergen_Susu_Jahe,AdAidEnergen_Kacang_Hijau,AdAidEnergen_Susu_Vanilla,AdAidKelloggs_Corn_Flakes,AdAidMilo,AdAidNestle_Koko_Krunch,AdAidNestle_Honey_Star,AdAidQuaker_Biru,AdAidQuaker_Merah,AdAidEnergen_Sereal_and_Susu_Jagung,ConsL3MEnergen_Oat_berry,ConsL3MEnergen_Oat_banana,ConsL3MEnergen_Susu_Chocolate,ConsL3MEnergen_Susu_Jahe,ConsL3MEnergen_Kacang_Hijau,ConsL3MEnergen_Susu_Vanilla,ConsL3MKelloggs_Corn_Flakes,ConsL3MMilo,ConsL3MNestle_Koko_Krunch,ConsL3MNestle_Honey_Star,ConsL3MQuaker_Biru,ConsL3MQuaker_Merah,ConsL3MEnergen_Sereal_and_Susu_Jagung,ConsLMEnergen_Oat_berry,ConsLMEnergen_Oat_banana,ConsLMEnergen_Susu_Chocolate,ConsLMEnergen_Susu_Jahe,ConsLMEnergen_Kacang_Hijau,ConsLMEnergen_Susu_Vanilla,ConsLMKelloggs_Corn_Flakes,ConsLMMilo,ConsLMNestle_Koko_Krunch,ConsLMNestle_Honey_Star,ConsLMQuaker_Biru,ConsLMQuaker_Merah,ConsLMEnergen_Sereal_and_Susu_Jagung,CATEGORY_Cereal,CATEGORY_Ch_Food+Bev,CATEGORY_Powder_milk,CATEGORY_Bread,CATEGORY_Sweet_Con_Milk,Cereals_Self,Cereals_Husband,Cereals_Ch_less5yr,Cereals_Ch_5to14yr,Cereals_Ch_greater14yr,Cereals_Other_adults,Choc_food_beve_Self,Choc_food_beve_Husband,Choc_food_beve_Ch_less5yr,Choc_food_beve_Ch_5to14yr,Choc_food_beve_Ch_greater14yr,Choc_food_beve_Other_adults,Powd_Milk_Self,Powd_Milk_Husband,Powd_Milk_Ch_less5yr,Powd_Milk_Ch_5to14yr,Powd_Milk_Ch_greater14yr,Powd_Milk_Other_adults,Bread_Self,Bread_Husband,Bread_Ch_less5yr,Bread_Ch_5to14yr,Bread_Ch_greater14yr,Bread_Other_adults,Sweet_Cond_Milk_Self,Sweet_Cond_Milk_Husband,Sweet_Cond_Milk_Ch_less5yr,Sweet_Cond_Milk_Ch_5to14yr,Sweet_Cond_Milk_Ch_greater14yr,Sweet_Cond_Milk_Other_adults,BrTom_Ceremix_Nutritious_Cereal,BrTom_Energen,BrTom_Milo,BrTom_Nestle,BrSpont_Ceremix_Nutritious_Cereal,BrSpont_Energen,BrSpont_Milo,BrSpont_Nestle,BrAided_Ceremix_Nutritious_Cereal,BrAided_Energen,BrAided_Milo,BrAided_Nestle,AdTom_Ceremix_Nutritious_Cereal,AdTom_Energen,AdTom_Milo,AdTom_Nestle,AdSpont_Ceremix_Nutritious_Cereal,AdSpont_Energen,AdSpont_Milo,AdSpont_Nestle,AdAided_Ceremix_Nutritious_Cereal,AdAided_Energen,AdAided_Milo,AdAided_Nestle,Fav_Ceremix_Nutritious_Cereal,Fav_Energen,Fav_Milo,Fav_Nestle,Bumo_Ceremix_Nutritious_Cereal,Bumo_Energen,Bumo_Milo,Bumo_Nestle,ConsL3M_Ceremix_Nutritious_Cereal,ConsL3M_Energen,ConsL3M_Milo,ConsL3M_Nestle,ConsLM_Ceremix_Nutritious_Cereal,ConsLM_Energen,ConsLM_Milo,ConsLM_Nestle,BrTom_BK,AdTom_BK,FAVORITEBRAND_BK,BUMO_BK,r33c4_1,r33c4_2,r33c4_4,r33c4_6,r33c4_8,r33c4_9,r33c4_12,r33c4_13,r33c4_14,r33c5_1,r33c5_2,r33c5_4,r33c5_6,r33c5_8,r33c5_9,r33c5_12,r33c5_13,r33c5_14,r33c7_1,r33c7_2,r33c7_4,r33c7_6,r33c7_8,r33c7_9,r33c7_12,r33c7_13,r33c7_14,r33c9_1,r33c9_2,r33c9_4,r33c9_6,r33c9_8,r33c9_9,r33c9_12,r33c9_13,r33c9_14,r33c10_1,r33c10_2,r33c10_4,r33c10_6,r33c10_8,r33c10_9,r33c10_12,r33c10_13,r33c10_14,BrSpontGoW_Chocolate,BrAidGoW_Chocolate,AdSpontGoW_Chocolate,AdAidGoW_Chocolate,ConsL3MGoW_Chocolate,ConsLMGoW_Chocolate,BrSpontGoW_Vanilla,BrAidGoW_Vanilla,AdSpontGoW_Vanilla,AdAidGoW_Vanilla,ConsL3MGoW_Vanilla,ConsLMGoW_Vanilla,BrTom_GoWell_NET,BrSpont_GoWell_NET,BrAided_GoWell_NET,AdTom_GoWell_NET,AdSpont_GoWell_NET,AdAided_GoWell_NET,Fav_GoWell_NET,Bumo_GoWell_NET,ConsL3M_GoWell_NET,ConsLM_GoWell_NET,ConsP1WEnergen_Oat_berry,ConsP1WEnergen_Oat_banana,ConsP1WEnergen_Susu_Chocolate,ConsP1WEnergen_Susu_Jahe,ConsP1WEnergen_Kacang_Hijau,ConsP1WEnergen_Susu_Vanilla,ConsP1WKelloggs_Corn_Flakes,ConsP1WMilo,ConsP1WNestle_Koko_Krunch,ConsP1WNestle_Honey_Star,ConsP1WQuaker_Biru,ConsP1WQuaker_Merah,ConsP1WEnergen_Sereal_and_Susu_Jagung,ConsP1WGoW_Vanilla,ConsP1WGoW_Chocolate,ConsP1DEnergen_Oat_berry,ConsP1DEnergen_Oat_banana,ConsP1DEnergen_Susu_Chocolate,ConsP1DEnergen_Susu_Jahe,ConsP1DEnergen_Kacang_Hijau,ConsP1DEnergen_Susu_Vanilla,ConsP1DKelloggs_Corn_Flakes,ConsP1DMilo,ConsP1DNestle_Koko_Krunch,ConsP1DNestle_Honey_Star,ConsP1DQuaker_Biru,ConsP1DQuaker_Merah,ConsP1DEnergen_Sereal_and_Susu_Jagung,ConsP1DGoW_Vanilla,ConsP1DGoW_Chocolate,ConsP1W_Energen,P1W_Net_Milo,P1W_Net_Nestle,P1W_Net_Ceremix_Nutritious_Cereal,ConsP1W_GoWell_NET,ConsP1D_Energen,P1D_Net_Milo,P1D_Net_Nestle,P1D_Net_Ceremix_Nutritious_Cereal,ConsP1D_GoWell_NET) " + "VALUES('" + userID + "','" + userEmail + "','" + firstName + "','" + lastName + "','" + UserStatus + "','" + gender + "','" + maritalStatus + "','" + education + "','" + race + "','" + religion + "','" + postCode + "','" + country + "','" + city + "','" + subDistrict + "','" + village + "','" + incomeRange + "','" + industryName + "','" + occupation + "','" + SURVEY_ID + "','" + SURVEY_PERIOD + "','" + weightage + "','" + SURVEY_PERIOD + "','" + location + "','" + AgeGroup + "','" + ses + "','" + period + "','" + cerealpanel + "','" + r27c + "','" + r31c + "','" + r19_1 + "','" + r19_2 + "','" + r19_3 + "','" + r19_4 + "','" + r19_5 + "','" + r19_6 + "','" + r19_7 + "','" + r20 + "','" + r27a + "','" + r27b_11 + "','" + r27b_12 + "','" + r27b_15 + "','" + r27b_16 + "','" + r27b_17 + "','" + r27b_18 + "','" + r27b_24 + "','" + r27b_30 + "','" + r27b_36 + "','" + r27b_41 + "','" + r27b_52 + "','" + r27b_53 + "','" + r27b_83 + "','" + r30a_11 + "','" + r30a_12 + "','" + r30a_15 + "','" + r30a_16 + "','" + r30a_17 + "','" + r30a_18 + "','" + r30a_24 + "','" + r30a_30 + "','" + r30a_36 + "','" + r30a_41 + "','" + r30a_52 + "','" + r30a_53 + "','" + r30a_83 + "','" + r27d + "','" + r27e_11 + "','" + r27e_12 + "','" + r27e_15 + "','" + r27e_16 + "','" + r27e_17 + "','" + r27e_18 + "','" + r27e_24 + "','" + r27e_30 + "','" + r27e_36 + "','" + r27e_41 + "','" + r27e_52 + "','" + r27e_53 + "','" + r27e_83 + "','" + r30b_11 + "','" + r30b_12 + "','" + r30b_15 + "','" + r30b_16 + "','" + r30b_17 + "','" + r30b_18 + "','" + r30b_24 + "','" + r30b_30 + "','" + r30b_36 + "','" + r30b_41 + "','" + r30b_52 + "','" + r30b_53 + "','" + r30b_83 + "','" + r31a_11 + "','" + r31a_12 + "','" + r31a_15 + "','" + r31a_16 + "','" + r31a_17 + "','" + r31a_18 + "','" + r31a_24 + "','" + r31a_30 + "','" + r31a_36 + "','" + r31a_41 + "','" + r31a_52 + "','" + r31a_53 + "','" + r31a_83 + "','" + r31b_11 + "','" + r31b_12 + "','" + r31b_15 + "','" + r31b_16 + "','" + r31b_17 + "','" + r31b_18 + "','" + r31b_24 + "','" + r31b_30 + "','" + r31b_36 + "','" + r31b_41 + "','" + r31b_52 + "','" + r31b_53 + "','" + r31b_83 + "','" + r24a_1 + "','" + r24a_2 + "','" + r24a_3 + "','" + r24a_4 + "','" + r24a_5 + "','" + r24br1_1 + "','" + r24br1_2 + "','" + r24br1_3 + "','" + r24br1_4 + "','" + r24br1_5 + "','" + r24br1_6 + "','" + r24br2_1 + "','" + r24br2_2 + "','" + r24br2_3 + "','" + r24br2_4 + "','" + r24br2_5 + "','" + r24br2_6 + "','" + r24br3_1 + "','" + r24br3_2 + "','" + r24br3_3 + "','" + r24br3_4 + "','" + r24br3_5 + "','" + r24br3_6 + "','" + r24br4_1 + "','" + r24br4_2 + "','" + r24br4_3 + "','" + r24br4_4 + "','" + r24br4_5 + "','" + r24br4_6 + "','" + r24br5_1 + "','" + r24br5_2 + "','" + r24br5_3 + "','" + r24br5_4 + "','" + r24br5_5 + "','" + r24br5_6 + "','" + r27an_1 + "','" + r27an_2 + "','" + r27an_10 + "','" + r27an_12 + "','" + r27bn_1 + "','" + r27bn_2 + "','" + r27bn_10 + "','" + r27bn_12 + "','" + r30an_1 + "','" + r30an_2 + "','" + r30an_10 + "','" + r30an_12 + "','" + r27dn_1 + "','" + r27dn_2 + "','" + r27dn_10 + "','" + r27dn_12 + "','" + r27en_1 + "','" + r27en_2 + "','" + r27en_10 + "','" + r27en_12 + "','" + r30bn_1 + "','" + r30bn_2 + "','" + r30bn_10 + "','" + r30bn_12 + "','" + r27cn_1 + "','" + r27cn_2 + "','" + r27cn_10 + "','" + r27cn_12 + "','" + r31cn_1 + "','" + r31cn_2 + "','" + r31cn_10 + "','" + r31cn_12 + "','" + r31an_1 + "','" + r31an_2 + "','" + r31an_10 + "','" + r31an_12 + "','" + r31bn_1 + "','" + r31bn_2 + "','" + r31bn_10 + "','" + r31bn_12 + "','" + r27a + "','" + r27d + "','" + r27c + "','" + r31c + "','" + r33c4_1 + "','" + r33c4_2 + "','" + r33c4_4 + "','" + r33c4_6 + "','" + r33c4_8 + "','" + r33c4_9 + "','" + r33c4_12 + "','" + r33c4_13 + "','" + r33c4_14 + "','" + r33c5_1 + "','" + r33c5_2 + "','" + r33c5_4 + "','" + r33c5_6 + "','" + r33c5_8 + "','" + r33c5_9 + "','" + r33c5_12 + "','" + r33c5_13 + "','" + r33c5_14 + "','" + r33c7_1 + "','" + r33c7_2 + "','" + r33c7_4 + "','" + r33c7_6 + "','" + r33c7_8 + "','" + r33c7_9 + "','" + r33c7_12 + "','" + r33c7_13 + "','" + r33c7_14 + "','" + r33c9_1 + "','" + r33c9_2 + "','" + r33c9_4 + "','" + r33c9_6 + "','" + r33c9_8 + "','" + r33c9_9 + "','" + r33c9_12 + "','" + r33c9_13 + "','" + r33c9_14 + "','" + r33c10_1 + "','" + r33c10_2 + "','" + r33c10_4 + "','" + r33c10_6 + "','" + r33c10_8 + "','" + r33c10_9 + "','" + r33c10_12 + "','" + r33c10_13 + "','" + r33c10_14 + "','" + BrSpontGoW_Chocolate + "','" + BrAidGoW_Chocolate + "','" + AdSpontGoW_Chocolate + "','" + AdAidGoW_Chocolate + "','" + ConsL3MGoW_Chocolate + "','" + ConsLMGoW_Chocolate + "','" + BrSpontGoW_Vanilla + "','" + BrAidGoW_Vanilla + "','" + AdSpontGoW_Vanilla + "','" + AdAidGoW_Vanilla + "','" + ConsL3MGoW_Vanilla + "','" + ConsLMGoW_Vanilla + "','" + BrTom_GoWell_NET + "','" + BrSpont_GoWell_NET + "','" + BrAided_GoWell_NET + "','" + AdTom_GoWell_NET + "','" + AdSpont_GoWell_NET + "','" + AdAided_GoWell_NET + "','" + Fav_GoWell_NET + "','" + Bumo_GoWell_NET + "','" + ConsL3M_GoWell_NET + "','" + ConsLM_GoWell_NET + "' ,'" + r137a_11 + "','" + r137a_12 + "','" + r137a_15 + "','" + r137a_16 + "','" + r137a_17 + "','" + r137a_18 + "','" + r137a_24 + "','" + r137a_30 + "','" + r137a_36 + "','" + r137a_41 + "','" + r137a_52 + "','" + r137a_53 + "','" + r137a_83 + "','" + ConsP1WGoW_Vanilla + "','" + ConsP1WGoW_Chocolate + "','" + r291_11 + "','" + r291_12 + "','" + r291_15 + "','" + r291_16 + "','" + r291_17 + "','" + r291_18 + "','" + r291_24 + "','" + r291_30 + "','" + r291_36 + "','" + r291_41 + "','" + r291_52 + "','" + r291_53 + "','" + r291_83 + "','" + ConsP1DGoW_Vanilla + "','" + ConsP1DGoW_Chocolate + "','" + ConsP1W_Energen + "','" + r137an_10 + "','" + r137an_12 + "','" + r137an_1 + "','" + ConsP1W_GoWell_NET + "','" + ConsP1D_Energen + "','" + r291n_10 + "','" + r291n_12 + "','" + r291n_1 + "','" + ConsP1D_GoWell_NET + "')", connection);
            try
            {
                cmd.ExecuteNonQuery();
                Console.WriteLine("Data inserted successfully");
                i = 1;
            }
            catch (Exception ex)
            {

                connection.Close();
                i = 0;
                Console.WriteLine("Exception occured" + ex.ToString());
                Console.WriteLine("Exception occured");

                Console.ReadLine();
            }
            connection.Close();
        }

        internal void insert_Dashboard_values_BI(string userID, int SURVEY_ID, string period, string r33c4_1, string r33c4_2, string r33c4_4, string r33c4_6, string r33c4_8, string r33c4_9, string r33c4_12, string r33c4_13, string r33c4_14, string r33c5_1, string r33c5_2, string r33c5_4, string r33c5_6, string r33c5_8, string r33c5_9, string r33c5_12, string r33c5_13, string r33c5_14, string r33c7_1, string r33c7_2, string r33c7_4, string r33c7_6, string r33c7_8, string r33c7_9, string r33c7_12, string r33c7_13, string r33c7_14, string r33c9_1, string r33c9_2, string r33c9_4, string r33c9_6, string r33c9_8, string r33c9_9, string r33c9_12, string r33c9_13, string r33c9_14, string r33c10_1, string r33c10_2, string r33c10_4, string r33c10_6, string r33c10_8, string r33c10_9, string r33c10_12, string r33c10_13, string r33c10_14)
        {
            int i;
            connection.Open();
            //SqlConnection connection = new SqlConnection("Data Source=52.74.59.117;Initial Catalog=ClueboxMobile;Persist Security Info=True;User ID=sa;Password=ClueBox123*;");
            SqlCommand cmd = new SqlCommand("INSERT INTO DashboardFlatTabJava_m2cereal_BI_temp (UserID,SurveyID,Period,r33c4_1,r33c4_2,r33c4_4,r33c4_6,r33c4_8,r33c4_9,r33c4_12,r33c4_13,r33c4_14,r33c5_1,r33c5_2,r33c5_4,r33c5_6,r33c5_8,r33c5_9,r33c5_12,r33c5_13,r33c5_14,r33c7_1,r33c7_2,r33c7_4,r33c7_6,r33c7_8,r33c7_9,r33c7_12,r33c7_13,r33c7_14,r33c9_1,r33c9_2,r33c9_4,r33c9_6,r33c9_8,r33c9_9,r33c9_12,r33c9_13,r33c9_14,r33c10_1,r33c10_2,r33c10_4,r33c10_6,r33c10_8,r33c10_9,r33c10_12,r33c10_13,r33c10_14) " + "VALUES('" + userID + "','" + SURVEY_ID + "','" + period + "','" + r33c4_1 + "','" + r33c4_2 + "','" + r33c4_4 + "','" + r33c4_6 + "','" + r33c4_8 + "','" + r33c4_9 + "','" + r33c4_12 + "','" + r33c4_13 + "','" + r33c4_14 + "','" + r33c5_1 + "','" + r33c5_2 + "','" + r33c5_4 + "','" + r33c5_6 + "','" + r33c5_8 + "','" + r33c5_9 + "','" + r33c5_12 + "','" + r33c5_13 + "','" + r33c5_14 + "','" + r33c7_1 + "','" + r33c7_2 + "','" + r33c7_4 + "','" + r33c7_6 + "','" + r33c7_8 + "','" + r33c7_9 + "','" + r33c7_12 + "','" + r33c7_13 + "','" + r33c7_14 + "','" + r33c9_1 + "','" + r33c9_2 + "','" + r33c9_4 + "','" + r33c9_6 + "','" + r33c9_8 + "','" + r33c9_9 + "','" + r33c9_12 + "','" + r33c9_13 + "','" + r33c9_14 + "','" + r33c10_1 + "','" + r33c10_2 + "','" + r33c10_4 + "','" + r33c10_6 + "','" + r33c10_8 + "','" + r33c10_9 + "','" + r33c10_12 + "','" + r33c10_13 + "','" + r33c10_14 + "')", connection);
            try
            {
                cmd.ExecuteNonQuery();
                Console.WriteLine("Data inserted successfully");
                i = 1;
            }
            catch (Exception ex)
            {

                connection.Close();
                i = 0;
                Console.WriteLine("Exception occured" + ex.ToString());
                Console.WriteLine("Exception occured");

                Console.ReadLine();
            }
            connection.Close();
        }
    }

}
