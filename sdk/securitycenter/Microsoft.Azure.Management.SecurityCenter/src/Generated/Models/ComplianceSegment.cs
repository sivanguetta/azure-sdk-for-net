// <auto-generated>
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
//
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.
// </auto-generated>

namespace Microsoft.Azure.Management.Security.Models
{
    using Newtonsoft.Json;
    using System.Linq;

    /// <summary>
    /// A segment of a compliance assessment.
    /// </summary>
    public partial class ComplianceSegment
    {
        /// <summary>
        /// Initializes a new instance of the ComplianceSegment class.
        /// </summary>
        public ComplianceSegment()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the ComplianceSegment class.
        /// </summary>
        /// <param name="segmentType">The segment type, e.g. compliant,
        /// non-compliance, insufficient coverage, N/A, etc.</param>
        /// <param name="percentage">The size (%) of the segment.</param>
        public ComplianceSegment(string segmentType = default(string), double? percentage = default(double?))
        {
            SegmentType = segmentType;
            Percentage = percentage;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// Gets the segment type, e.g. compliant, non-compliance, insufficient
        /// coverage, N/A, etc.
        /// </summary>
        [JsonProperty(PropertyName = "segmentType")]
        public string SegmentType { get; private set; }

        /// <summary>
        /// Gets the size (%) of the segment.
        /// </summary>
        [JsonProperty(PropertyName = "percentage")]
        public double? Percentage { get; private set; }

    }
}