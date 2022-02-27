using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Xunit;
using Xunit.Abstractions;
using enigma_core.Models;
using enigma_core.Repository;
using enigma_core.Models;

namespace XUnitTests.enigma_core_tests.Repositories
{
    public class SettingsRepository_unitTest
    {
        private readonly ITestOutputHelper output;

        public SettingsRepository_unitTest(ITestOutputHelper output)
        {
            this.output = output;

        }

        [Fact]
        public void test_test()
        {
            Settings item = new Settings();
            item.id = 1;
            item.key = "esta es la llave";
            item.order = 2;

            //obtenemos que valores del modelo estan llenos
            List<Object> InsertFildsAndValues = new List<Object>();

            foreach (PropertyInfo pi in item.GetType().GetProperties())
            {
                var valueInModel = pi.GetValue(item, null)?.ToString();
                if (valueInModel == null) continue;
                var obj = new { field = pi.Name, valueSqlParam = "sql_Param_" + pi.Name, value = valueInModel };
                InsertFildsAndValues.Add(obj);
            }

            //construimos los campos a insertar y los valores a insertar
            string fields = "(";
            int index = 0;
            foreach (var obj in InsertFildsAndValues)
            {
                var itemSelected = new { field = "", valueSqlParam = "sql_Param_", value = "" };
                itemSelected = Cast(itemSelected, obj);
                fields += (index > 0) ? "," : "";
                fields += itemSelected.field;
                index++;
            }

            fields += ")";
        }

        [Fact]
        public void test_Add_AgregarItemABD()
        {
            SettingsRepository settingRepo = new SettingsRepository();
            Settings newSetting = new Settings();
            newSetting.key = "admin.carga";
            newSetting.display_name = "Carga adminsitrador";
            newSetting.value = "Valor de carga";
            newSetting.details = "este es el detalle";
            newSetting.type = "text";
            newSetting.order = 1;
            newSetting.group = "Admim";

            settingRepo.Add(newSetting);
        }

        [Fact]
        public async void test_add_agregarItemDbAsync()
        {
            SettingsRepository settingRepo = new SettingsRepository();
            Settings newSetting = new Settings();
            newSetting.key = "admin.carga2";
            newSetting.display_name = "Carga adminsitrador";
            newSetting.value = "Valor de carga";
            newSetting.details = "este es el detalle";
            newSetting.type = "text";
            newSetting.order = 1;
            newSetting.group = "Admim";

            await settingRepo.AddAsync(newSetting);
        }

        [Fact]
        public void test_update_UpdateItem()
        {
            SettingsRepository settingRepo = new SettingsRepository();
            Settings updateSetting = new Settings();
            updateSetting.details = "dato actualizado del detalle";
            settingRepo.Update(23, updateSetting);

        }

        [Fact]
        public async void test_update_UpdateItemAsync()
        {
            SettingsRepository settingRepo = new SettingsRepository();
            Settings updateSetting = new Settings();
            updateSetting.details = "dato actualizado del detalle async";
            await settingRepo.UpdateAsync(23, updateSetting);

        }

        [Fact]
        public void test_delete_deleteRecord()
        {
            SettingsRepository settingRepo = new SettingsRepository();
            settingRepo.Detelete(24);
        }

        [Fact]
        public async void test_deleteAsync_deleteRecord()
        {
            SettingsRepository settingRepo = new SettingsRepository();
            await settingRepo.DeleteAsync(23);
        }

        private static T Cast<T>(T typeHolder, Object x)
        {
            // typeHolder above is just for compiler magic
            // to infer the type to cast x to
            return (T)x;
        }
    }
}
