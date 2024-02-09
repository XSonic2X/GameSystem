using GameSystem.Game_Properties.Player;
using System;

namespace GameSystem.Game_Properties.Effect
{
    [Serializable]
    public class MPoint : Meaning
    {
        public MPoint(TypePoints typePoints, bool pointMax, bool p1) 
        { 
            typeP = typePoints;
            this.pointMax = pointMax;
            this.p1 = p1;
        }
        Point point;
        TypePoints typeP;
        /// <summary>
        /// Выбор Мак поинт
        /// </summary>
        bool pointMax;
        bool p1 = true;
        event VoidEvent VEStart;
        event VoidEvent VEEnd;
        public override void InstallEvent(GAction gAction)
        {
            if (pointMax) { return; }
            VEStart += gAction.Unuse;
            VEEnd += gAction.Use;
        }
        public override void UninstallEvent(GAction gAction)
        {
            if (pointMax) { return; }
            VEStart -= gAction.Unuse;
            VEEnd -= gAction.Use;
        }
        public void UpdateStarte(Point p) => VEStart?.Invoke();
        public void UpdateEnd(Point p) => VEEnd?.Invoke();
        public override int Get()
        {
            if (pointMax) { return point.pointMax; }
            return point.point;
        }
        public override void Set(int num) 
        {
            if (pointMax) { return; }
            point.point = num;
        }
        public override string ToString()
        {
            if (point == null)
            {
                if (pointMax) { return $"Макс.{GameString.PointToString(typeP)}:-0"; }
                return $"{GameString.PointToString(typeP)}:-0";
            }
            if (pointMax) { return $"Макс.{GameString.PointToString(typeP)}:{point.pointMax}"; }
            return $"{GameString.PointToString(typeP)}:{point.point}";
        }

        public override void Update(Game_Elements.Effect effect, Game_Objects.Entity p1, Game_Objects.Entity p2)
        {
            if (this.p1) { point = p1[typeP]; }
            else { point = p2[typeP]; }
            if (VEStart != null)
            {
                VEStart = null;
                VEEnd = null;
            }
            if (pointMax)
            {
                point.ePointMaxStart += UpdateStarte;
                point.ePointMaxEnd += UpdateEnd;
            }
            else
            {
                point.ePointStart += UpdateStarte;
                point.ePointEnd += UpdateEnd;
            }
        }

        public override bool Validity()
        {
            return point != null;
        }

        public override Meaning Cloning()
        {
            return new MPoint(typeP, pointMax, p1);
        }
    }
}
