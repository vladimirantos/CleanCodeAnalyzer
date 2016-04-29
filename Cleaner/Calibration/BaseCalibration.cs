using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cleaner.Analyzer.Statistics;
using Cleaner.Utils;

namespace Cleaner.Calibration
{
    interface ICalibration<in T> where T : BaseStatistic
    {
        /// <summary>
        /// Provádí výpočet průměrných hodnot nad metrikou T.
        /// </summary>
        void Calibrate(IEnumerable<T> collection);

        void Save(string path);
    }

    internal abstract class BaseCalibration<T> : ICalibration<T> where T : BaseStatistic
    {
        protected const int NoneRounding = 0;
        protected const int RoundTwoDecimal = 2;
        protected ConfigurationWriter CalibrationWriter { get; }
        protected IEnumerable<T> Collection { get; private set; } = new List<T>();

        protected BaseCalibration(ConfigurationWriter writer)
        {
            CalibrationWriter = writer;
        }

        /// <summary>
        /// Provádí výpočet průměrných hodnot nad metrikou T.
        /// </summary>
        public virtual void Calibrate(IEnumerable<T> collection) => Collection = collection;
        
        public void Save(string path) => CalibrationWriter.Save(path);

        /// <summary>
        /// Spočítá průměrnou hodnotu v kolekci enumerable podle zadané podmínky.
        /// </summary>
        /// <param name="enumerable">Kolekce nad kterou se vypočte průměr.</param>
        /// <param name="expression">Omezující podmínka pro hodnoty v kolekci.</param>
        /// <param name="roundDecimal">Určí počet desetinných míst na která se bude zaokrouhlovat.</param>
        protected double Avg(IEnumerable<T> enumerable, Func<T, int> expression, int roundDecimal)
            => Math.Round(enumerable.Average(expression), roundDecimal);

        /// <summary>
        /// Spočítá průměrnou hodnotu nad kolekcí zadanou konstruktorem.
        /// </summary>
        /// <param name="expression">Omezující podmínka pro hodnoty v kolekci.</param>
        /// <param name="roundDecimal">Určí počet desetinných míst na která se bude zaokrouhlovat.</param>
        /// <returns></returns>
        protected double Avg(Func<T, int> expression, int roundDecimal)
            => Math.Round(Collection.Average(expression), roundDecimal);

        /// <summary>
        /// Přidá do konfiguračního souboru zadaný klíč a jako hodnotu průměru ze zadané kolekce omezené podmínkou expression.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="collection">Kolekce nad kterou se vypočte průměr.</param>
        /// <param name="expression">Omezující podmínka pro hodnoty v kolekci.</param>
        /// <param name="roundDecimal">Určí počet desetinných míst na která se bude zaokrouhlovat.</param>
        protected void AddCalibrationValue(string key, IEnumerable<T> collection, Func<T, int> expression,
            int roundDecimal = NoneRounding)
            => CalibrationWriter.Add(key, Avg(collection, expression, roundDecimal));

        /// <summary>
        /// Spočítá průměrnou hodnotu pro kolekci zadanou konstruktorem.
        /// </summary>
        /// <param name="key"></param>
        /// <param name="expression">Omezující podmínka pro hodnoty v kolekci.</param>
        /// <param name="roundDecimal">Určí počet desetinných míst na která se bude zaokrouhlovat.</param>
        protected void AddCalibrationValue(string key, Func<T, int> expression, int roundDecimal = NoneRounding)
            => AddCalibrationValue(key, Collection, expression, roundDecimal);
    }
}
