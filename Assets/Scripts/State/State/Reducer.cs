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

    public virtual string GetReducerName() {
        return null;
    }

    public virtual void handleAction(Action action) {
        if (action is Thunk) {
            Thunk thunk=(Thunk)action;
            thunk.execute(GameDataManager.GetInstance());
        }
        else foreach(KeyValuePair<string, Reducer> child in children) {
            child.Value.handleAction(action);
        }
    }

    public Reducer getItem(string key) {
        return children[key];
    }

    private Dictionary<string, Reducer> children = new Dictionary<string, Reducer>();

    public void AddChildReducer(Reducer child) {
        string reducerName = child.GetReducerName();
        if (reducerName == null) {
            reducerName = child.GetType().ToString();
        }
        AddChildReducer(child, reducerName);
    }

    public void AddChildReducer(Reducer child, string name) {
        Debug.Log("Adding Reducer "+name);
        children.Add(name, child);
    }
}
