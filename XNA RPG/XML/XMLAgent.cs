using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using XNA_RPG.Mapping;
using XNA_RPG.Character;
using XNA_RPG.Menu;

namespace XNA_RPG.XML
{
    public class XMLAgent
    {
        #region Constructors
        /// <summary>
        /// This is the empty constructor for XMLAgent.
        /// </summary>
        public XMLAgent()
        {
        }
        #endregion

        #region Methods
        /// <summary>
        /// This method reads a file and instantiates a Combatant.
        /// </summary>
        /// <param name="filename">the file to read</param>
        /// <returns>a new Combatant</returns>
        public Combatant ReadCombatant(string filename)
        {
            XmlTextReader reader = new XmlTextReader(filename);
            Combatant comb = new Combatant();

            while (reader.Read())
            {
                if (reader.NodeType == XmlNodeType.Element)
                {
                    if (reader.LocalName.Equals("Name"))
                    {
                        comb.Name = reader.ReadString();
                    }
                    else if (reader.LocalName.Equals("Level"))
                    {
                        comb.Level = reader.ReadContentAsInt();
                    }
                    else if (reader.LocalName.Equals("EXP"))
                    {
                        comb.EXP = reader.ReadContentAsInt();
                    }
                    else if (reader.LocalName.Equals("HP"))
                    {
                        comb.HP = reader.ReadContentAsInt();
                    }
                    else if (reader.LocalName.Equals("MP"))
                    {
                        comb.MP = reader.ReadContentAsInt();
                    }
                    else if (reader.LocalName.Equals("ATK"))
                    {
                        comb.ATK = reader.ReadContentAsInt();
                    }
                    else if (reader.LocalName.Equals("DEF"))
                    {
                        comb.DEF = reader.ReadContentAsInt();
                    }
                    else if (reader.LocalName.Equals("MRST"))
                    {
                        comb.MRST = reader.ReadContentAsInt();
                    }
                    else if (reader.LocalName.Equals("EVA"))
                    {
                        comb.EVA = reader.ReadContentAsInt();
                    }
                    else if (reader.LocalName.Equals("MEVA"))
                    {
                        comb.MEVA = reader.ReadContentAsInt();
                    }
                    else if (reader.LocalName.Equals("STR"))
                    {
                        comb.STR = reader.ReadContentAsInt();
                    }
                    else if (reader.LocalName.Equals("MPOW"))
                    {
                        comb.MPOW = reader.ReadContentAsInt();
                    }
                    else if (reader.LocalName.Equals("VIT"))
                    {
                        comb.VIT = reader.ReadContentAsInt();
                    }
                    else if (reader.LocalName.Equals("SPD"))
                    {
                        comb.SPD = reader.ReadContentAsInt();
                    }
                }
            }

            return comb;
        }

        /// <summary>
        /// This method writes a file with the stats of a Combatant.
        /// </summary>
        /// <param name="comb">Combatant whose stats are to be written</param>
        /// <param name="filename">the file to which to write</param>
        public void WriteCombatant(Combatant comb, string filename)
        {
            XmlTextWriter writer = new XmlTextWriter(filename, null);

            try
            {
                writer.Formatting = Formatting.Indented;
                writer.Indentation = 4;
                writer.Namespaces = false;

                writer.WriteStartDocument();
                writer.WriteStartElement("Combatant");

                writer.WriteStartElement("Name");
                writer.WriteString(comb.Name);
                writer.WriteEndElement();

                writer.WriteStartElement("Level");
                writer.WriteValue(comb.Level);
                writer.WriteEndElement();

                writer.WriteStartElement("EXP");
                writer.WriteValue(comb.EXP);
                writer.WriteEndElement();
                
                writer.WriteStartElement("HP");
                writer.WriteValue(comb.HP);
                writer.WriteEndElement();

                writer.WriteStartElement("MP");
                writer.WriteValue(comb.MP);
                writer.WriteEndElement();

                writer.WriteStartElement("ATK");
                writer.WriteValue(comb.ATK);
                writer.WriteEndElement();

                writer.WriteStartElement("DEF");
                writer.WriteValue(comb.DEF);
                writer.WriteEndElement();

                writer.WriteStartElement("MRST");
                writer.WriteValue(comb.MRST);
                writer.WriteEndElement();

                writer.WriteStartElement("EVA");
                writer.WriteValue(comb.EVA);
                writer.WriteEndElement();

                writer.WriteStartElement("MEVA");
                writer.WriteValue(comb.MEVA);
                writer.WriteEndElement();

                writer.WriteStartElement("STR");
                writer.WriteValue(comb.STR);
                writer.WriteEndElement();

                writer.WriteStartElement("MPOW");
                writer.WriteValue(comb.MPOW);
                writer.WriteEndElement();

                writer.WriteStartElement("VIT");
                writer.WriteValue(comb.VIT);
                writer.WriteEndElement();

                writer.WriteStartElement("SPD");
                writer.WriteValue(comb.SPD);
                writer.WriteEndElement();

                writer.WriteEndElement();
                writer.Flush();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: {0}",e.ToString());
            }
            finally
            {
                if (writer != null)
                {
                    writer.Close();
                }
            }
        }

        public Map ReadMap(string filename)
        {
            XmlTextReader reader = new XmlTextReader(filename);
            Map map = new Map();

            while (reader.Read())
            {
                if (reader.NodeType == XmlNodeType.Element)
                {
                    if (reader.LocalName.Equals("Width"))
                    {
                        map.Width = reader.ReadContentAsInt();
                    }
                    else if (reader.LocalName.Equals("Height"))
                    {
                        map.Height = reader.ReadContentAsInt();
                    }
                    else if (reader.LocalName.Equals("Bottom Layer"))
                    {
                    }
                    else if (reader.LocalName.Equals("Middle Layer"))
                    {
                    }
                    else if (reader.LocalName.Equals("Top Layer"))
                    {
                    }
                }
            }

            return map;
        }

        public void WriteMap(Map map, string filename)
        {
            XmlTextWriter writer = new XmlTextWriter(filename, null);

            try
            {
                writer.Formatting = Formatting.Indented;
                writer.Indentation = 4;
                writer.Namespaces = false;

                writer.WriteStartDocument();
                writer.WriteStartElement("Map");

                writer.WriteEndElement();
                writer.Flush();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: {0}", e.ToString());
            }
            finally
            {
                if (writer != null)
                {
                    writer.Close();
                }
            }
        }
        #endregion
    }
}
