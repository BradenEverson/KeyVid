using KeyVid.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace KeyVid.Database
{
    public interface IVideoData
    {
        public Video add(Video video);
        public Video update(Video video);
        public Video delete(Video video);
        public Video getAllByUser(Guid guid);
        public Video getById(Guid id);
    }
}
