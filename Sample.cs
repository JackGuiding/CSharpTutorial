using System;
using System.Numerics;
using System.Collections.Generic;

// 飞机
public class PlaneEntity {
    public int id;
    public Vector2 pos;
}

// 飞机仓库
public class PlaneRepository {

    Dictionary<int, PlaneEntity> all;

    public PlaneRepository() {
        all = new Dictionary<int, PlaneEntity>();
    }

    public void Add(PlaneEntity entity) {
        all.Add(entity.id, entity);
    }

    public PlaneEntity FindByID(int id) {
        // 看字典里有没有
        all.TryGetValue(id, out PlaneEntity entity);
        return entity;
    }

    public void FindX(Predicate<PlaneEntity> predicate) {
        foreach (var plane in all.Values) {
            bool isTrue = predicate.Invoke(plane);
            if (isTrue) {
                System.Console.WriteLine($"Plane {plane.id} at {plane.pos}");
            }
        }
    }

    public void ForeachInside(Vector2 center, float radius, Action<PlaneEntity> action) {
        foreach (var plane in all.Values) {
            if (Vector2.Distance(plane.pos, center) < radius) {
                action.Invoke(plane);
            }
        }
    }

}

public static class Sample {

    public static void Entry() {
        PlaneRepository repo = new PlaneRepository();
        // o o o o 4
        // o o o x 2
        // o o - o 3
        // o 1 o o o
        // o o o o o
        repo.Add(new PlaneEntity() { id = 1, pos = new Vector2(-1, -1) });
        repo.Add(new PlaneEntity() { id = 2, pos = new Vector2(2, 1) });
        repo.Add(new PlaneEntity() { id = 3, pos = new Vector2(0, 2) });
        repo.Add(new PlaneEntity() { id = 4, pos = new Vector2(2, 2) });

        repo.ForeachInside(new Vector2(1, 1), 2, LogPlane);
        repo.FindX(FindIDLess3);
        repo.FindX(FIndIDMoreThan2);

    }

    static void LogPlane(PlaneEntity plane) {
        System.Console.WriteLine($"Plane {plane.id} at {plane.pos}");
    }

    static bool FindIDLess3(PlaneEntity plane) {
        if (plane.id < 3) {
            return true;
        } else {
            return false;
        }
    }

    static bool FIndIDMoreThan2(PlaneEntity plane) {
        if (plane.id > 2) {
            return true;
        } else {
            return false;
        }
    }

}