﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnkaPhilipsChannelEditor
{
    public class OnkaChannelName
    {
        public string Name { get; set; }
        public string Suffix { get; set; }
        public int NameLength { get; set; }
        public int SuffixLength { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
/*
    public class ChannelMapModel
    {
        public List<ChannelModel> Channels { get; set; }
    }
    
    public class ChannelModel
    {
        public SetupModel Setup { get; set; }
        public BroadcastModel Broadcast { get; set; }
    }

    public class SetupModel
    {
        public string SatelliteName { get; set; }
        public int ChannelNumber { get; set; }
        public string ChannelName { get; set; }
        public string ChannelLock { get; set; }
        public string UserModifiedName { get; set; }
        public string LogoID { get; set; }
        public string UserModifiedLogo { get; set; }
        public string LogoLock { get; set; }
        public string UserHidden { get; set; }
        public string FavoriteNumber { get; set; }
    }

    public class BroadcastModel
    {
        public string ChannelType { get; set; }
        public string Onid { get; set; }
        public string Tsid { get; set; }
        public string Sid { get; set; }
        public string Frequency { get; set; }
        public string Modulation { get; set; }
        public string ServiceType { get; set; }
        public string SymbolRate { get; set; }
        public string LNBNumber { get; set; }
        public string Polarization { get; set; }
        public string SystemHidden { get; set; }
    }
*/

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
    public partial class ChannelMap
    {

        private ChannelMapChannel[] channelField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Channel")]
        public ChannelMapChannel[] Channel
        {
            get
            {
                return this.channelField;
            }
            set
            {
                this.channelField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class ChannelMapChannel
    {

        private ChannelMapChannelSetup setupField;

        private ChannelMapChannelBroadcast broadcastField;

        /// <remarks/>
        public ChannelMapChannelSetup Setup
        {
            get
            {
                return this.setupField;
            }
            set
            {
                this.setupField = value;
            }
        }

        /// <remarks/>
        public ChannelMapChannelBroadcast Broadcast
        {
            get
            {
                return this.broadcastField;
            }
            set
            {
                this.broadcastField = value;
            }
        }

        public override string ToString()
        {
            return Setup.ChannelNumber + " - " + Setup._niceChannelName;
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class ChannelMapChannelSetup
    {

        private string satelliteNameField;

        private int channelNumberField;

        private string channelNameField;

        private int channelLockField;

        private int userModifiedNameField;

        private int logoIDField;

        private int userModifiedLogoField;

        private int logoLockField;

        private int userHiddenField;

        private int favoriteNumberField;

        private int scrambleField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string SatelliteName
        {
            get
            {
                return this.satelliteNameField;
            }
            set
            {
                this.satelliteNameField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public int ChannelNumber
        {
            get
            {
                return this.channelNumberField;
            }
            set
            {
                this.channelNumberField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string ChannelName
        {
            get
            {
                return this.channelNameField;
            }
            set
            {
                this.channelNameField = value;
                _niceChannelName = OnkaHelper.GetChannelName(channelNameField);
            }
        }
        [System.Xml.Serialization.XmlIgnore]
        public OnkaChannelName _niceChannelName = new OnkaChannelName();

        [System.Xml.Serialization.XmlIgnore]
        public string _ChannelNameSuffix = "";

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public int ChannelLock
        {
            get
            {
                return this.channelLockField;
            }
            set
            {
                this.channelLockField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public int UserModifiedName
        {
            get
            {
                return this.userModifiedNameField;
            }
            set
            {
                this.userModifiedNameField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public int LogoID
        {
            get
            {
                return this.logoIDField;
            }
            set
            {
                this.logoIDField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public int UserModifiedLogo
        {
            get
            {
                return this.userModifiedLogoField;
            }
            set
            {
                this.userModifiedLogoField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public int LogoLock
        {
            get
            {
                return this.logoLockField;
            }
            set
            {
                this.logoLockField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public int UserHidden
        {
            get
            {
                return this.userHiddenField;
            }
            set
            {
                this.userHiddenField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public int FavoriteNumber
        {
            get
            {
                return this.favoriteNumberField;
            }
            set
            {
                this.favoriteNumberField = value;
            }
        }

        [System.Xml.Serialization.XmlAttributeAttribute()]
        public int Scramble
        {
            get
            {
                return this.scrambleField;
            }
            set
            {
                this.scrambleField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class ChannelMapChannelBroadcast
    {
        private int uniqueIDField;

        private int channelTypeField;

        private int onidField;

        private int tsidField;

        private int sidField;

        private int frequencyField;

        private string modulationField;

        private int serviceTypeField;

        private int symbolRateField;

        private int lNBNumberField;

        private int polarizationField;

        private int systemHiddenField;

        private int bandwidthField;

        private int decoderTypeField;

        private int subTypeField;

        private int networkIDField;

        private int streamPriorityField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public int UniqueID
        {
            get
            {
                return this.uniqueIDField;
            }
            set
            {
                this.uniqueIDField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public int ChannelType
        {
            get
            {
                return this.channelTypeField;
            }
            set
            {
                this.channelTypeField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public int Onid
        {
            get
            {
                return this.onidField;
            }
            set
            {
                this.onidField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public int Tsid
        {
            get
            {
                return this.tsidField;
            }
            set
            {
                this.tsidField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public int Sid
        {
            get
            {
                return this.sidField;
            }
            set
            {
                this.sidField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public int Frequency
        {
            get
            {
                return this.frequencyField;
            }
            set
            {
                this.frequencyField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Modulation
        {
            get
            {
                return this.modulationField;
            }
            set
            {
                this.modulationField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public int ServiceType
        {
            get
            {
                return this.serviceTypeField;
            }
            set
            {
                this.serviceTypeField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public int SymbolRate
        {
            get
            {
                return this.symbolRateField;
            }
            set
            {
                this.symbolRateField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public int LNBNumber
        {
            get
            {
                return this.lNBNumberField;
            }
            set
            {
                this.lNBNumberField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public int Polarization
        {
            get
            {
                return this.polarizationField;
            }
            set
            {
                this.polarizationField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public int SystemHidden
        {
            get
            {
                return this.systemHiddenField;
            }
            set
            {
                this.systemHiddenField = value;
            }
        }

        [System.Xml.Serialization.XmlAttributeAttribute()]
        public int Bandwidth
        {
            get
            {
                return this.bandwidthField;
            }
            set
            {
                this.bandwidthField = value;
            }
        }

        [System.Xml.Serialization.XmlAttributeAttribute()]
        public int DecoderType
        {
            get
            {
                return this.decoderTypeField;
            }
            set
            {
                this.decoderTypeField = value;
            }
        }

        [System.Xml.Serialization.XmlAttributeAttribute()]
        public int SubType
        {
            get
            {
                return this.subTypeField;
            }
            set
            {
                this.subTypeField = value;
            }
        }

        [System.Xml.Serialization.XmlAttributeAttribute()]
        public int NetworkID
        {
            get
            {
                return this.networkIDField;
            }
            set
            {
                this.networkIDField = value;
            }
        }

        [System.Xml.Serialization.XmlAttributeAttribute()]
        public int StreamPriority
        {
            get
            {
                return this.streamPriorityField;
            }
            set
            {
                this.streamPriorityField = value;
            }
        }
    }


}
