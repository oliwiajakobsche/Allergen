import React, { useEffect, useRef, useState } from 'react';
import styled from 'styled-components/native'
import {createBottomTabNavigator} from '@react-navigation/bottom-tabs'
import ProfileScreen from './ProfileScreen';
import CallendarScreen from './CallendarScreen';
import {View, Text, StyleSheet} from 'react-native';
import { FontAwesomeIcon} from '@fortawesome/react-native-fontawesome';
import { faCalendarDay, faUserCircle } from '@fortawesome/free-solid-svg-icons';


const Tab = createBottomTabNavigator();

const TabNavigator = () => {
  return (
    <Tab.Navigator
        screenOptions={({route}) => ({
            tabBarLabel: ({focused}) => 
            (
                <Text>{route.name == 'Profil' ? 'Profil' : 'Kalendarz'}</Text>
            ),
            tabBarIcon: ({focused}) =>
            route.name === 'Profil' ?  
            ((<TabIcon focused={focused}>
                <FontAwesomeIcon icon={faUserCircle} size={28} style={focused ? { color: '#64b976'} :  {color: 'grey'}}/>
              </TabIcon>))
            : 
            ((<TabIcon focused={focused}>
                <FontAwesomeIcon icon={faCalendarDay} size={28} style={focused ? { color: '#64b976'} :  {color: 'grey'}}/>
              </TabIcon>)),
        })}>
        <Tab.Screen name={'Profil'} component={ProfileScreen}  />
        <Tab.Screen name={'Kalendarz'} component={CallendarScreen} />
    </Tab.Navigator>
  );
};

const TabIcon = styled(View)`
    opacity: ${p => p.focused ? 1.0 : 0.8};
`;


export default TabNavigator;