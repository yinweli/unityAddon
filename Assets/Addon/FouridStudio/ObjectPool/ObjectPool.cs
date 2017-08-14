using System;
using System.Collections.Generic;

namespace FouridStudio
{
    /// <summary>
    /// 物件池類別
    /// 注意!不支援多執行緒
    /// </summary>
    /// <typeparam name="T">物件型別</typeparam>
    public class ObjectPool<T> where T : new()
    {
        /// <summary>
        /// 委派型態:建立物件
        /// </summary>
        /// <returns>物件</returns>
        public delegate T CreateObject();

        /// <summary>
        /// 委派型態:分配物件, 必須傳回obj
        /// </summary>
        /// <param name="obj">分配物件</param>
        /// <returns>分配物件</returns>
        public delegate T AllocObject(T obj);

        /// <summary>
        /// 委派型態:釋放物件, 必須傳回obj
        /// </summary>
        /// <param name="obj">釋放物件</param>
        /// <returns>釋放物件</returns>
        public delegate T FreeObject(T obj);

        /// <summary>
        /// 當可用物件不足時, 分派的新物件數量
        /// </summary>
        public int growSize = 100;

        /// <summary>
        /// 建立物件委派
        /// </summary>
        public CreateObject createObject = null;

        /// <summary>
        /// 分配物件委派
        /// </summary>
        public AllocObject allocObject = null;

        /// <summary>
        /// 釋放物件委派
        /// </summary>
        public FreeObject freeObject = null;

        /// <summary>
        /// 物件列表
        /// </summary>
        private T[] objects = null;

        /// <summary>
        /// 使用索引
        /// </summary>
        private int nextIndex = 0;

        /// <summary>
        /// 建立物件
        /// </summary>
        /// <returns>建立物件</returns>
        public T alloc()
        {
            if (objects == null || nextIndex >= objects.Length)
                resize();

            T obj = objects[nextIndex++];

            return allocObject != null ? allocObject(obj) : obj;
        }

        /// <summary>
        /// 釋放物件
        /// </summary>
        /// <param name="obj">釋放物件</param>
        public void free(T obj)
        {
            if (nextIndex > 0)
                objects[--nextIndex] = freeObject != null ? freeObject(obj) : obj;
        }

        /// <summary>
        /// 釋放物件
        /// </summary>
        /// <param name="objs">釋放物件列表</param>
        public void free(IEnumerable<T> objs)
        {
            foreach (T itor in objs)
                free(itor);
        }

        /// <summary>
        /// 調整物件池大小
        /// </summary>
        private void resize()
        {
            int oldSize = 0;
            T[] newObjects = null;

            if (objects != null)
            {
                oldSize = objects.Length;
                newObjects = new T[oldSize + growSize];

                Array.Copy(objects, newObjects, oldSize);
            }
            else
                newObjects = new T[growSize];

            for (int i = oldSize; i < newObjects.Length; ++i)
                newObjects[i] = createObject != null ? createObject() : new T();

            objects = newObjects;
        }
    }
}