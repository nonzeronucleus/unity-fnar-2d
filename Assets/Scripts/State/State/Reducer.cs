using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Reducer
{
    public virtual void init() {
        foreach(KeyValuePair<string, Reducer> child in children) {
            child.Value.init();
        }
    }

    public virtual void handleAction(Action action) {
        foreach(KeyValuePair<string, Reducer> child in children) {
            child.Value.handleAction(action);
        }
    }

    public Reducer getItem(string key) {
        return children[key];
    }

    private Dictionary<string, Reducer> children = new Dictionary<string, Reducer>();

    public void AddChildReducer(Reducer child) {
        AddChildReducer(child, child.GetType().ToString());
    }

    public void AddChildReducer(Reducer child, string name) {
        children.Add(name, child);
    }
}
