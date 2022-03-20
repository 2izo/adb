using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Concurrency;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;

namespace adbNoob.helpers
{
    public class StreamObservable
    {
        public static IObservable<string> ReadLines(StreamReader stream)
        {
#pragma warning disable CS8619 // Nullability of reference types in value doesn't match target type.
            return Observable.Using(
                () => stream,
                reader => Observable.FromAsync(reader.ReadLineAsync)
                                    .Repeat()
                                    .TakeWhile(line => line != null));
#pragma warning restore CS8619 // Nullability of reference types in value doesn't match target type.
        }
        static IEnumerable<string> ObserveLines(Stream stream)
        {
            using (StreamReader reader = new StreamReader(stream))
            {
                while (!reader.EndOfStream)
                   yield return reader.ReadLine();
            }
        }

        public static IObservable<string> ReadLines(Stream inputStream)
        {
            return ObserveLines(inputStream).ToObservable(Scheduler.ThreadPool);
        }
    }
}
