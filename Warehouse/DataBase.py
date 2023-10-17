from kivy.uix.popup import Popup
from kivy.uix.treeview import TreeView, TreeViewNode, TreeViewLabel
from os import listdir

import sqlite3

class CreateNewBase(Popup):
    title = 'Создание базы'

    def create_base(self, Name_base):
        
        if Name_base != '':

            path_base = 'Data base/'+Name_base +'.db'

            conn = sqlite3.connect(path_base)

            cur = conn.cursor()
            cur.execute("""CREATE TABLE IF NOT EXISTS materials(
                parent TEXT,
                name_mat TEXT,
                article TEXT,
                CONSTRAINT mat PRIMARY KEY (name_mat,article,parent)); """)

            cur.execute("""CREATE TABLE IF NOT EXISTS device(
                parent TEXT,
                model TEXT,
                number_dev TEXT,
                CONSTRAINT dev PRIMARY KEY (model,number_dev,parent)); """)

            cur.execute("""CREATE TABLE IF NOT EXISTS warehouse(
                area TEXT,
                name_warehouse TEXT,
                CONSTRAINT ware PRIMARY KEY (name_warehouse,area)); """)

            cur.execute("""CREATE TABLE IF NOT EXISTS stock_balance(
                name_doc TEXT,
                number_doc TEXT,
                name_warehouse TEXT,
                area TEXT,
                move_doc TEXT,
                name_mat TEXT,
                article TEXT,
                units REAL,
                CONSTRAINT balance PRIMARY KEY (number_doc,move_doc)); """)

            cur.execute("""CREATE TABLE IF NOT EXISTS written_off_to_the_device(
                name_doc TEXT,
                number_doc TEXT,
                parent TEXT,
                model TEXT,
                number_dev TEXT,
                units REAL,
                CONSTRAINT written_off PRIMARY KEY (number_doc,number_dev,parent)); """)            

            conn.commit() 

            conn.close() 

class ConnectBase(Popup):
    title = "Подключение к базе"

    def build(self):
        Bases = listdir('data')
        treeview = self.ids.get('tv')
        
        for el in Bases:
            treeview.add_node(TreeViewLabel(text='data/'+el))



class DatabaseManagement():
    
    def connection_base(self, path_base):
        return sqlite3.connect(path_base)

def creating_a_new_record_materials():
    pass

def creating_a_new_record_device():
    pass

def creating_a_new_record_warehouse():
    pass

