﻿using System.ComponentModel;

namespace System.IO.Abstractions
{
    [Serializable]
    public abstract class FileSystemWatcherBase : IDisposable
    {
        public abstract bool EnableRaisingEvents { get; set; }
        public abstract string Filter { get; set; }
        public abstract int InternalBufferSize { get; set; }
        public abstract NotifyFilters NotifyFilter { get; set; }
        public abstract string Path { get; set; }
        public abstract ISite Site { get; set; }
        public abstract ISynchronizeInvoke SynchronizingObject { get; set; }
        public virtual event FileSystemEventHandler Changed;
        public virtual event FileSystemEventHandler Created;
        public virtual event FileSystemEventHandler Deleted;
        public virtual event ErrorEventHandler Error;
        public virtual event RenamedEventHandler Renamed;
        public abstract void BeginInit();
        public abstract void Dispose();
        public abstract void EndInit();
        public abstract WaitForChangedResult WaitForChanged(WatcherChangeTypes changeType);
        public abstract WaitForChangedResult WaitForChanged(WatcherChangeTypes changeType, int timeout);

        public static implicit operator FileSystemWatcherBase(FileSystemWatcher watcher)
        {
            return new FileSystemWatcherWrapper(watcher);
        }

        protected void OnCreated(object sender, FileSystemEventArgs args)
        {
            var onCreated = Created;
            if (onCreated != null)
            {
                onCreated(sender, args);
            }
        }

        protected void OnChanged(object sender, FileSystemEventArgs args)
        {
            var onChanged = Changed;
            if (onChanged != null)
            {
                onChanged(sender, args);
            }
        }

        protected void OnDeleted(object sender, FileSystemEventArgs args)
        {
            var onDeleted = Deleted;
            if (onDeleted != null)
            {
                onDeleted(sender, args);
            }
        }

        protected void OnRenamed(object sender, RenamedEventArgs args)
        {
            var onRenamed = Renamed;
            if (onRenamed != null)
            {
                onRenamed(sender, args);
            }
        }

        protected void OnError(object sender, ErrorEventArgs args)
        {
            var onError = Error;
            if (onError != null)
            {
                onError(sender, args);
            }
        }
    }
}