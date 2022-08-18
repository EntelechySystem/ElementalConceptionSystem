"""
@File   : GraphDataBase.py
@Author : Ethan Lin
@Date   : 2022/08/17
@Desc   : 
"""

from unittest import TestCase


class DbModelTest(TestCase):
    node=[
        {'_id':1,'name':'foo'},
        {'_id':2,'name':'bar'},
    ]
    edges=[
        {'_from':1,'_to':2},
    ]
    def setUp(self):
        self.db=Dagoba(self.nodes)