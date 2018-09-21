using System;
using System.Collections.Generic;
using UnityEngine;

using Object = UnityEngine.Object;

internal class ObjectCacheRec
{
    public const float DatedTime = 300f;

    private bool _isPermanent;
    private Object _cachedObject;
    private float _lastAccessTime;
    private readonly List<string> _groupNames;

    public ObjectCacheRec()
    {
        _groupNames = new List<string>();
    }

    /// <summary>
    /// ���������
    /// </summary>
	public Object CachedObject
    {
        get
        {
            return _cachedObject;
        }
        set
        {
            _cachedObject = value;
        }
    }

    /// <summary>
    /// ��һ�η��ʵ��¼�
    /// </summary>
	public float LastAccessTime
    {
        get
        {
            return _lastAccessTime;
        }
        set
        {
            _lastAccessTime = value;
        }
    }

    /// <summary>
    /// ��ǰ��Դ�Ƿ����ô����ڻ���
    /// </summary>
    public bool IsPermanent
    {
        get
        {
            return _isPermanent;
        }
        set
        {
            _isPermanent = value;
        }
    }

    /// <summary>
    /// �Ƿ������
    /// </summary>
	public bool IsDated
    {
        get
        {
            return Time.realtimeSinceStartup - _lastAccessTime > DatedTime;
        }
    }

    /// <summary>
    /// �Ƿ񻺴��˸÷���
    /// </summary>
    /// <param name="groupName"></param>
    /// <returns></returns>
	public bool IsCachedForGroup(string groupName)
    {
        return _groupNames.Contains(groupName);
    }

    /// <summary>
    /// �Ƿ��з���
    /// </summary>
    /// <returns></returns>
	public bool HasGroupName()
    {
        return _groupNames.Count > 0;
    }

    /// <summary>
    /// �Ƴ�����
    /// </summary>
    /// <param name="groupName"></param>
    /// <returns></returns>
	public bool RemoveGroupName(string groupName)
    {
        return _groupNames.Remove(groupName);
    }

    /// <summary>
    /// ��ӷ���
    /// </summary>
    /// <param name="groupName"></param>
	public void AddGroupName(string groupName)
    {
        if (!_groupNames.Contains(groupName))
        {
            _groupNames.Add(groupName);
        }
    }
}
