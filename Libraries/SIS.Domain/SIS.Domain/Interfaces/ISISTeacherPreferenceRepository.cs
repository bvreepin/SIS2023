﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIS.Domain.Interfaces
{
    public interface ISISTeacherPreferenceRepository
    {
        public Dictionary<string, TeacherPreference> TeacherPreferences { get; }

        public Dictionary<string, TeacherPreference> RefreshTeacherPreferences();
        public bool Exists(TeacherPreference teacherPreference);
        public void Insert(TeacherPreference teacherPreference);
        public void Update(TeacherPreference teacherPreferenceToUpdate, TeacherPreference newTeacherPreference);
        public void Delete(TeacherPreference teacherPreference);
    }
}
