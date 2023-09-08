using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace WinFormsApp2
{
    public class Target
    {
        const double mm2inch = 25.4;

        public string Class { get; set; }
        public string Name { get; set; }
        public double ROTx { get; set; }
        public double ROTy { get; set; }
        public double Distance { get; set; }
        public Uom DistanceUom { get; set; }
        public Uom DimensionsUom { get; set; }
        public double Aim { get; set; }
        public double Outer { get; set; }
        public double Magpie { get; set; }
        public double Inner { get; set; }
        public double Bull { get; set; }
        public double VBull { get; set; }


        public decimal ROTxInMetric
        {
            get { return DimensionsUom == Uom.inch ? (decimal)(ROTx * mm2inch) : (decimal)ROTx; }
        }
        public decimal ROTyInMetric
        {
            get { return DimensionsUom == Uom.inch ? (decimal)(ROTy * mm2inch) : (decimal)ROTy; }
        }
        public decimal AimInMetric
        {
            get { return DimensionsUom == Uom.inch ? (decimal)(Aim * mm2inch) : (decimal)Aim; }
        }
        public decimal OuterInMetric
        {
            get { return DimensionsUom == Uom.inch ? (decimal)(Outer * mm2inch) : (decimal)Outer; }
        }
        public decimal MagpieInMetric
        {
            get { return DimensionsUom == Uom.inch ? (decimal)(Magpie * mm2inch) : (decimal)Magpie; }
        }
        public decimal InnerInMetric
        {
            get { return DimensionsUom == Uom.inch ? (decimal)(Inner * mm2inch) : (decimal)Inner; }
        }
        public decimal BullInMetric
        {
            get { return DimensionsUom == Uom.inch ? (decimal)(Bull * mm2inch) : (decimal)Bull; }
        }
        public decimal VBullInMetric
        {
            get { return DimensionsUom == Uom.inch ? (decimal)(VBull * mm2inch) : (decimal)VBull; }
        }

    }
    public enum Uom
    {
        Yards,
        Meters,
        inch,
        mm
    }
}
