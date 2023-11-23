using System.Text;
using Flickr.Net.Flickrs.Results;
using Flickr.Net.Internals;

namespace Flickr.Net.Test.Entities;

public class PhotoExifTests
{
    [Fact]
    public void JsonStringToPhotoExif()
    {
        var json = /*lang=json,strict*/ """
            {
                "photo": {
                    "id": "52989708325",
                    "secret": "c6c6943038",
                    "server": "65535",
                    "farm": 66,
                    "camera": "Nikon D750",
                    "exif": [
                        {
                            "tagspace": "IFD0",
                            "tagspaceid": 0,
                            "tag": "Compression",
                            "label": "Compression",
                            "raw": {
                                "_content": "JPEG (old-style)"
                            }
                        },
                        {
                            "tagspace": "IFD0",
                            "tagspaceid": 0,
                            "tag": "Make",
                            "label": "Make",
                            "raw": {
                                "_content": "NIKON CORPORATION"
                            }
                        },
                        {
                            "tagspace": "IFD0",
                            "tagspaceid": 0,
                            "tag": "Model",
                            "label": "Model",
                            "raw": {
                                "_content": "NIKON D750"
                            }
                        },
                        {
                            "tagspace": "IFD0",
                            "tagspaceid": 0,
                            "tag": "XResolution",
                            "label": "X-Resolution",
                            "raw": {
                                "_content": "300"
                            },
                            "clean": {
                                "_content": "300 dpi"
                            }
                        },
                        {
                            "tagspace": "IFD0",
                            "tagspaceid": 0,
                            "tag": "YResolution",
                            "label": "Y-Resolution",
                            "raw": {
                                "_content": "300"
                            },
                            "clean": {
                                "_content": "300 dpi"
                            }
                        },
                        {
                            "tagspace": "IFD0",
                            "tagspaceid": 0,
                            "tag": "ResolutionUnit",
                            "label": "Resolution Unit",
                            "raw": {
                                "_content": "inches"
                            }
                        },
                        {
                            "tagspace": "IFD0",
                            "tagspaceid": 0,
                            "tag": "Software",
                            "label": "Software",
                            "raw": {
                                "_content": "NIKON D750 Ver.1.15"
                            }
                        },
                        {
                            "tagspace": "IFD0",
                            "tagspaceid": 0,
                            "tag": "ModifyDate",
                            "label": "Date and Time (Modified)",
                            "raw": {
                                "_content": "2023:06:20 18:14:20"
                            }
                        },
                        {
                            "tagspace": "IFD0",
                            "tagspaceid": 0,
                            "tag": "YCbCrPositioning",
                            "label": "YCbCr Positioning",
                            "raw": {
                                "_content": "Centered"
                            }
                        },
                        {
                            "tagspace": "ExifIFD",
                            "tagspaceid": 0,
                            "tag": "ExposureTime",
                            "label": "Exposure",
                            "raw": {
                                "_content": "1\/60"
                            },
                            "clean": {
                                "_content": "0.017 sec (1\/60)"
                            }
                        },
                        {
                            "tagspace": "ExifIFD",
                            "tagspaceid": 0,
                            "tag": "FNumber",
                            "label": "Aperture",
                            "raw": {
                                "_content": "22.0"
                            },
                            "clean": {
                                "_content": "f\/22.0"
                            }
                        },
                        {
                            "tagspace": "ExifIFD",
                            "tagspaceid": 0,
                            "tag": "ExposureProgram",
                            "label": "Exposure Program",
                            "raw": {
                                "_content": "Manual"
                            }
                        },
                        {
                            "tagspace": "ExifIFD",
                            "tagspaceid": 0,
                            "tag": "ISO",
                            "label": "ISO Speed",
                            "raw": {
                                "_content": "100"
                            }
                        },
                        {
                            "tagspace": "ExifIFD",
                            "tagspaceid": 0,
                            "tag": "SensitivityType",
                            "label": "Sensitivity Type",
                            "raw": {
                                "_content": "Recommended Exposure Index"
                            }
                        },
                        {
                            "tagspace": "ExifIFD",
                            "tagspaceid": 0,
                            "tag": "ExifVersion",
                            "label": "Exif Version",
                            "raw": {
                                "_content": "0231"
                            }
                        },
                        {
                            "tagspace": "ExifIFD",
                            "tagspaceid": 0,
                            "tag": "DateTimeOriginal",
                            "label": "Date and Time (Original)",
                            "raw": {
                                "_content": "2023:06:20 07:33:13"
                            }
                        },
                        {
                            "tagspace": "ExifIFD",
                            "tagspaceid": 0,
                            "tag": "CreateDate",
                            "label": "Date and Time (Digitized)",
                            "raw": {
                                "_content": "2023:06:20 07:33:13"
                            }
                        },
                        {
                            "tagspace": "ExifIFD",
                            "tagspaceid": 0,
                            "tag": "OffsetTime",
                            "label": "Offset Time",
                            "raw": {
                                "_content": "+02:00"
                            }
                        },
                        {
                            "tagspace": "ExifIFD",
                            "tagspaceid": 0,
                            "tag": "OffsetTimeOriginal",
                            "label": "Offset Time Original",
                            "raw": {
                                "_content": "+02:00"
                            }
                        },
                        {
                            "tagspace": "ExifIFD",
                            "tagspaceid": 0,
                            "tag": "ComponentsConfiguration",
                            "label": "Components Configuration",
                            "raw": {
                                "_content": "Y, Cb, Cr, -"
                            }
                        },
                        {
                            "tagspace": "ExifIFD",
                            "tagspaceid": 0,
                            "tag": "ExposureCompensation",
                            "label": "Exposure Bias",
                            "raw": {
                                "_content": "0"
                            },
                            "clean": {
                                "_content": "0 EV"
                            }
                        },
                        {
                            "tagspace": "ExifIFD",
                            "tagspaceid": 0,
                            "tag": "MaxApertureValue",
                            "label": "Max Aperture Value",
                            "raw": {
                                "_content": "3.9"
                            }
                        },
                        {
                            "tagspace": "ExifIFD",
                            "tagspaceid": 0,
                            "tag": "MeteringMode",
                            "label": "Metering Mode",
                            "raw": {
                                "_content": "Multi-segment"
                            }
                        },
                        {
                            "tagspace": "ExifIFD",
                            "tagspaceid": 0,
                            "tag": "LightSource",
                            "label": "Light Source",
                            "raw": {
                                "_content": "Unknown"
                            }
                        },
                        {
                            "tagspace": "ExifIFD",
                            "tagspaceid": 0,
                            "tag": "Flash",
                            "label": "Flash",
                            "raw": {
                                "_content": "Off, Did not fire"
                            }
                        },
                        {
                            "tagspace": "ExifIFD",
                            "tagspaceid": 0,
                            "tag": "FocalLength",
                            "label": "Focal Length",
                            "raw": {
                                "_content": "35.0 mm"
                            },
                            "clean": {
                                "_content": "35 mm"
                            }
                        },
                        {
                            "tagspace": "ExifIFD",
                            "tagspaceid": 0,
                            "tag": "SubSecTimeOriginal",
                            "label": "Sub Sec Time Original",
                            "raw": {
                                "_content": "73"
                            }
                        },
                        {
                            "tagspace": "ExifIFD",
                            "tagspaceid": 0,
                            "tag": "SubSecTimeDigitized",
                            "label": "Sub Sec Time Digitized",
                            "raw": {
                                "_content": "73"
                            }
                        },
                        {
                            "tagspace": "ExifIFD",
                            "tagspaceid": 0,
                            "tag": "FlashpixVersion",
                            "label": "Flashpix Version",
                            "raw": {
                                "_content": "0100"
                            }
                        },
                        {
                            "tagspace": "ExifIFD",
                            "tagspaceid": 0,
                            "tag": "ColorSpace",
                            "label": "Color Space",
                            "raw": {
                                "_content": "sRGB"
                            }
                        },
                        {
                            "tagspace": "ExifIFD",
                            "tagspaceid": 0,
                            "tag": "FocalPlaneXResolution",
                            "label": "Focal Plane X-Resolution",
                            "raw": {
                                "_content": "1675.014981"
                            }
                        },
                        {
                            "tagspace": "ExifIFD",
                            "tagspaceid": 0,
                            "tag": "FocalPlaneYResolution",
                            "label": "Focal Plane Y-Resolution",
                            "raw": {
                                "_content": "1675.014981"
                            }
                        },
                        {
                            "tagspace": "ExifIFD",
                            "tagspaceid": 0,
                            "tag": "FocalPlaneResolutionUnit",
                            "label": "Focal Plane Resolution Unit",
                            "raw": {
                                "_content": "cm"
                            }
                        },
                        {
                            "tagspace": "ExifIFD",
                            "tagspaceid": 0,
                            "tag": "SensingMethod",
                            "label": "Sensing Method",
                            "raw": {
                                "_content": "One-chip color area"
                            }
                        },
                        {
                            "tagspace": "ExifIFD",
                            "tagspaceid": 0,
                            "tag": "FileSource",
                            "label": "File Source",
                            "raw": {
                                "_content": "Digital Camera"
                            }
                        },
                        {
                            "tagspace": "ExifIFD",
                            "tagspaceid": 0,
                            "tag": "SceneType",
                            "label": "Scene Type",
                            "raw": {
                                "_content": "Directly photographed"
                            }
                        },
                        {
                            "tagspace": "ExifIFD",
                            "tagspaceid": 0,
                            "tag": "CFAPattern",
                            "label": "CFAPattern",
                            "raw": {
                                "_content": "[Red,Green][Green,Blue]"
                            }
                        },
                        {
                            "tagspace": "ExifIFD",
                            "tagspaceid": 0,
                            "tag": "CustomRendered",
                            "label": "Custom Rendered",
                            "raw": {
                                "_content": "Normal"
                            }
                        },
                        {
                            "tagspace": "ExifIFD",
                            "tagspaceid": 0,
                            "tag": "ExposureMode",
                            "label": "Exposure Mode",
                            "raw": {
                                "_content": "Manual"
                            }
                        },
                        {
                            "tagspace": "ExifIFD",
                            "tagspaceid": 0,
                            "tag": "WhiteBalance",
                            "label": "White Balance",
                            "raw": {
                                "_content": "Auto"
                            }
                        },
                        {
                            "tagspace": "ExifIFD",
                            "tagspaceid": 0,
                            "tag": "DigitalZoomRatio",
                            "label": "Digital Zoom Ratio",
                            "raw": {
                                "_content": "1"
                            }
                        },
                        {
                            "tagspace": "ExifIFD",
                            "tagspaceid": 0,
                            "tag": "FocalLengthIn35mmFormat",
                            "label": "Focal Length (35mm format)",
                            "raw": {
                                "_content": "35 mm"
                            }
                        },
                        {
                            "tagspace": "ExifIFD",
                            "tagspaceid": 0,
                            "tag": "SceneCaptureType",
                            "label": "Scene Capture Type",
                            "raw": {
                                "_content": "Standard"
                            }
                        },
                        {
                            "tagspace": "ExifIFD",
                            "tagspaceid": 0,
                            "tag": "GainControl",
                            "label": "Gain Control",
                            "raw": {
                                "_content": "None"
                            }
                        },
                        {
                            "tagspace": "ExifIFD",
                            "tagspaceid": 0,
                            "tag": "Contrast",
                            "label": "Contrast",
                            "raw": {
                                "_content": "Normal"
                            }
                        },
                        {
                            "tagspace": "ExifIFD",
                            "tagspaceid": 0,
                            "tag": "Saturation",
                            "label": "Saturation",
                            "raw": {
                                "_content": "Normal"
                            },
                            "clean": {
                                "_content": "High"
                            }
                        },
                        {
                            "tagspace": "ExifIFD",
                            "tagspaceid": 0,
                            "tag": "Sharpness",
                            "label": "Sharpness",
                            "raw": {
                                "_content": "Normal"
                            },
                            "clean": {
                                "_content": "Hard"
                            }
                        },
                        {
                            "tagspace": "ExifIFD",
                            "tagspaceid": 0,
                            "tag": "SubjectDistanceRange",
                            "label": "Subject Distance Range",
                            "raw": {
                                "_content": "Unknown"
                            }
                        },
                        {
                            "tagspace": "ExifIFD",
                            "tagspaceid": 0,
                            "tag": "LensInfo",
                            "label": "Lens Info",
                            "raw": {
                                "_content": "28-300mm f\/3.5-6.3"
                            }
                        },
                        {
                            "tagspace": "ExifIFD",
                            "tagspaceid": 0,
                            "tag": "LensModel",
                            "label": "Lens Model",
                            "raw": {
                                "_content": "TAMRON 28-300mm F3.5-6.3 Di VC PZD A010N"
                            }
                        },
                        {
                            "tagspace": "IPTC",
                            "tagspaceid": 0,
                            "tag": "CodedCharacterSet",
                            "label": "Coded Character Set",
                            "raw": {
                                "_content": "UTF8"
                            }
                        },
                        {
                            "tagspace": "IPTC",
                            "tagspaceid": 0,
                            "tag": "EnvelopeRecordVersion",
                            "label": "Envelope Record Version",
                            "raw": {
                                "_content": "4"
                            }
                        },
                        {
                            "tagspace": "IPTC",
                            "tagspaceid": 0,
                            "tag": "ApplicationRecordVersion",
                            "label": "Application Record Version",
                            "raw": {
                                "_content": "4"
                            }
                        },
                        {
                            "tagspace": "IPTC",
                            "tagspaceid": 0,
                            "tag": "DateCreated",
                            "label": "Date Created",
                            "raw": {
                                "_content": "2023:06:20"
                            }
                        },
                        {
                            "tagspace": "IPTC",
                            "tagspaceid": 0,
                            "tag": "TimeCreated",
                            "label": "Time Created",
                            "raw": {
                                "_content": "07:33:13-07:00"
                            }
                        },
                        {
                            "tagspace": "IPTC",
                            "tagspaceid": 0,
                            "tag": "DigitalCreationDate",
                            "label": "Digital Creation Date",
                            "raw": {
                                "_content": "2023:06:20"
                            }
                        },
                        {
                            "tagspace": "IPTC",
                            "tagspaceid": 0,
                            "tag": "DigitalCreationTime",
                            "label": "Digital Creation Time",
                            "raw": {
                                "_content": "07:33:13-07:00"
                            }
                        },
                        {
                            "tagspace": "Photoshop",
                            "tagspaceid": 0,
                            "tag": "IPTCDigest",
                            "label": "IPTCDigest",
                            "raw": {
                                "_content": "fff7b9473a9b06ea1f2b3b07262907e0"
                            }
                        },
                        {
                            "tagspace": "XMP-x",
                            "tagspaceid": 0,
                            "tag": "XMPToolkit",
                            "label": "XMPToolkit",
                            "raw": {
                                "_content": "Adobe XMP Core 7.0-c000 1.000000, 0000\/00\/00-00:00:00        "
                            }
                        },
                        {
                            "tagspace": "XMP-aux",
                            "tagspaceid": 0,
                            "tag": "ApproximateFocusDistance",
                            "label": "Approximate Focus Distance",
                            "raw": {
                                "_content": "5.62"
                            }
                        },
                        {
                            "tagspace": "XMP-aux",
                            "tagspaceid": 0,
                            "tag": "ImageNumber",
                            "label": "Image Number",
                            "raw": {
                                "_content": "62896"
                            }
                        },
                        {
                            "tagspace": "XMP-aux",
                            "tagspaceid": 0,
                            "tag": "Lens",
                            "label": "Lens",
                            "raw": {
                                "_content": "TAMRON 28-300mm F3.5-6.3 Di VC PZD A010N"
                            }
                        },
                        {
                            "tagspace": "XMP-aux",
                            "tagspaceid": 0,
                            "tag": "LensID",
                            "label": "Lens ID",
                            "raw": {
                                "_content": "236"
                            }
                        },
                        {
                            "tagspace": "XMP-crd",
                            "tagspaceid": 0,
                            "tag": "LookAmount",
                            "label": "Look Amount",
                            "raw": {
                                "_content": "1"
                            }
                        },
                        {
                            "tagspace": "XMP-crd",
                            "tagspaceid": 0,
                            "tag": "LookCopyright",
                            "label": "Look Copyright",
                            "raw": {
                                "_content": "\u00a9 2018 Adobe Systems, Inc."
                            }
                        },
                        {
                            "tagspace": "XMP-crd",
                            "tagspaceid": 0,
                            "tag": "LookGroup",
                            "label": "Look Group",
                            "raw": {
                                "_content": "Profiles"
                            }
                        },
                        {
                            "tagspace": "XMP-crd",
                            "tagspaceid": 0,
                            "tag": "LookName",
                            "label": "Look Name",
                            "raw": {
                                "_content": "Adobe Color"
                            }
                        },
                        {
                            "tagspace": "XMP-crd",
                            "tagspaceid": 0,
                            "tag": "LookParametersCameraProfile",
                            "label": "Look Parameters Camera Profile",
                            "raw": {
                                "_content": "Adobe Standard"
                            }
                        },
                        {
                            "tagspace": "XMP-crd",
                            "tagspaceid": 0,
                            "tag": "LookParametersConvertToGrayscale",
                            "label": "Look Parameters Convert To Grayscale",
                            "raw": {
                                "_content": "false"
                            }
                        },
                        {
                            "tagspace": "XMP-crd",
                            "tagspaceid": 0,
                            "tag": "LookParametersLookTable",
                            "label": "Look Parameters Look Table",
                            "raw": {
                                "_content": "E1095149FDB39D7A057BAB208837E2E1"
                            }
                        },
                        {
                            "tagspace": "XMP-crd",
                            "tagspaceid": 0,
                            "tag": "LookParametersProcessVersion",
                            "label": "Look Parameters Process Version",
                            "raw": {
                                "_content": "15.4"
                            }
                        },
                        {
                            "tagspace": "XMP-crd",
                            "tagspaceid": 0,
                            "tag": "LookParametersToneCurvePV2012",
                            "label": "Look Parameters Tone Curve PV2012",
                            "raw": {
                                "_content": "0, 0"
                            }
                        },
                        {
                            "tagspace": "XMP-crd",
                            "tagspaceid": 0,
                            "tag": "LookParametersToneCurvePV2012Blue",
                            "label": "Look Parameters Tone Curve PV2012 Blue",
                            "raw": {
                                "_content": "0, 0"
                            }
                        },
                        {
                            "tagspace": "XMP-crd",
                            "tagspaceid": 0,
                            "tag": "LookParametersToneCurvePV2012Green",
                            "label": "Look Parameters Tone Curve PV2012 Green",
                            "raw": {
                                "_content": "0, 0"
                            }
                        },
                        {
                            "tagspace": "XMP-crd",
                            "tagspaceid": 0,
                            "tag": "LookParametersToneCurvePV2012Red",
                            "label": "Look Parameters Tone Curve PV2012 Red",
                            "raw": {
                                "_content": "0, 0"
                            }
                        },
                        {
                            "tagspace": "XMP-crd",
                            "tagspaceid": 0,
                            "tag": "LookParametersVersion",
                            "label": "Look Parameters Version",
                            "raw": {
                                "_content": "15.4"
                            }
                        },
                        {
                            "tagspace": "XMP-crd",
                            "tagspaceid": 0,
                            "tag": "LookSupportsAmount",
                            "label": "Look Supports Amount",
                            "raw": {
                                "_content": "false"
                            }
                        },
                        {
                            "tagspace": "XMP-crd",
                            "tagspaceid": 0,
                            "tag": "LookSupportsMonochrome",
                            "label": "Look Supports Monochrome",
                            "raw": {
                                "_content": "false"
                            }
                        },
                        {
                            "tagspace": "XMP-crd",
                            "tagspaceid": 0,
                            "tag": "LookSupportsOutputReferred",
                            "label": "Look Supports Output Referred",
                            "raw": {
                                "_content": "false"
                            }
                        },
                        {
                            "tagspace": "XMP-crd",
                            "tagspaceid": 0,
                            "tag": "LookUUID",
                            "label": "Look UUID",
                            "raw": {
                                "_content": "B952C231111CD8E0ECCF14B86BAA7077"
                            }
                        },
                        {
                            "tagspace": "XMP-dc",
                            "tagspaceid": 0,
                            "tag": "Format",
                            "label": "Format",
                            "raw": {
                                "_content": "image\/jpeg"
                            }
                        },
                        {
                            "tagspace": "XMP-exifEX",
                            "tagspaceid": 0,
                            "tag": "SerialNumber",
                            "label": "Serial Number",
                            "raw": {
                                "_content": "2101486"
                            }
                        },
                        {
                            "tagspace": "XMP-exifEX",
                            "tagspaceid": 0,
                            "tag": "LensInfo",
                            "label": "Lens Info",
                            "raw": {
                                "_content": "28-300mm f\/3.5-6.3"
                            }
                        },
                        {
                            "tagspace": "XMP-xmp",
                            "tagspaceid": 0,
                            "tag": "CreatorTool",
                            "label": "Creator Tool",
                            "raw": {
                                "_content": "NIKON D750 Ver.1.15     "
                            }
                        },
                        {
                            "tagspace": "XMP-xmp",
                            "tagspaceid": 0,
                            "tag": "MetadataDate",
                            "label": "Metadata Date",
                            "raw": {
                                "_content": "2023:06:20 18:14:20+02:00"
                            }
                        },
                        {
                            "tagspace": "XMP-xmpMM",
                            "tagspaceid": 0,
                            "tag": "DocumentID",
                            "label": "Document ID",
                            "raw": {
                                "_content": "xmp.did:88d9cbd7-5e7b-4ea6-ae0f-bfce487a775c"
                            }
                        },
                        {
                            "tagspace": "XMP-xmpMM",
                            "tagspaceid": 0,
                            "tag": "InstanceID",
                            "label": "Instance ID",
                            "raw": {
                                "_content": "xmp.iid:88d9cbd7-5e7b-4ea6-ae0f-bfce487a775c"
                            }
                        },
                        {
                            "tagspace": "XMP-xmpMM",
                            "tagspaceid": 0,
                            "tag": "OriginalDocumentID",
                            "label": "Original Document ID",
                            "raw": {
                                "_content": "xmp.did:88d9cbd7-5e7b-4ea6-ae0f-bfce487a775c"
                            }
                        }
                    ]
                },
                "stat": "ok"
            }
            """;

        var result = FlickrConvert.DeserializeObject<FlickrResult<PhotoExif>>(Encoding.UTF8.GetBytes(json));

        Assert.NotNull(result);
        Assert.False(result.HasError);
        var items = result.Content;
        Assert.IsType<PhotoExif>(items);
        Assert.NotEmpty(items.Exifs);
        Assert.IsType<Exif>(items.Exifs[0]);
        Assert.Equal(88, items.Exifs.Count);
    }
}
