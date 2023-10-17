from kivy.app import App
from kivy.uix.tabbedpanel import TabbedPanel, TabbedPanelHeader
from kivy.uix.actionbar import ActionBar
from kivy.uix.button import Button
from kivy.uix.label import Label
from kivy.uix.treeview import TreeView, TreeViewNode, TreeViewLabel
from kivy.uix.widget import Widget

from kivy.uix.modalview import ModalView
from DataBase import CreateNewBase, ConnectBase


from kivy.uix.boxlayout import BoxLayout

path_base = ''

class FormOfMaterials(ModalView):
    pass

# Панель с вкладками
class TabbedPanelMain(TabbedPanel):
    pass

class CreateTab(TabbedPanelHeader):
    pass

class Table(BoxLayout):
    pass

class ConnectionBase(Label):
    pass

# Панель инструментов
class ActionBarMain(ActionBar):

    '''Панель инструментов'''

    def open_create_new_base(self):

        '''Окно создания базы данных'''

        popup = CreateNewBase()  
        popup.open()

    def connect_base(self):

        '''Окно подключения базы данных и поиск доступных баз'''
        
        popup = ConnectBase()
        popup.build()  
        popup.open()


class MainApp(App):
    
    '''Главное окно программы'''

    def __init__(self, **kwargs):

        '''Инициализация главного окна'''

        super().__init__(**kwargs)
        self.title = 'Складской учет'
        self.icon = 'source\image\Warehouse.png'
        

    def build(self):

        '''Построение интерфейса'''

        self.box = BoxLayout()
        self.box.orientation = 'vertical'
        self.ActionMenu = ActionBarMain()
        self.TabPanel = TabbedPanelMain()
        self.ConnectingBase = ConnectionBase()
        self.box.add_widget(self.ActionMenu)
        self.box.add_widget(self.TabPanel)
        self.box.add_widget(self.ConnectingBase)
        return self.box

    def new_tab(self, name):

        '''Создание новой вкладки и заполнение содержимого'''
        names_tab = []
        for tab in self.TabPanel.tab_list:
            names_tab.append(tab.text)

        if name not in names_tab:
            new_tab = CreateTab(text=name, content=Table())
            if name == 'Материалы':
                create_btn = new_tab.content.ids.get('create')
                create_btn.bind(on_release=self.open_window_materials)
            self.TabPanel.add_widget(new_tab)
            self.TabPanel.switch_to(new_tab)
        else:
            print('есть такой')   

    def remove_tab(self, del_tab):

        self.TabPanel.remove_widget(del_tab)

        if len(self.TabPanel.tab_list) > 0:
            if self.TabPanel.current_tab == del_tab:
                self.TabPanel.switch_to(self.TabPanel.tab_list[0])
        else:
            self.TabPanel.clear_widgets()   

    def select_base(self, *args):
        '''Выбор базы и перевод пути базы в глобальную переменную'''
        try:
            select = args[0].selected_node.text
            if select != 'Базы данных':
                global path_base
                path_base = select
                self.ConnectingBase.text = 'Подключено: /'+select
                args[1].dismiss()

            else:  
                print('Выберете базу')
                return True 
        except:
            error_know = ('Программист знает про эту ошибку и надо просто выбрать базу')
            print(error_know)
            return True

    def connect(self):
        pass    

    def open_window_materials(self, instance):
        window_materials = FormOfMaterials()
        window_materials.open()
        
# Запуск программы 
if __name__ == '__main__':
    MainApp().run()
    