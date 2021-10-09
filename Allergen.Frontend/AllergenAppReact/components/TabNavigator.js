import React from 'react';
import styled from 'styled-components/native'
import {createBottomTabNavigator} from '@react-navigation/bottom-tabs'
import { Text } from 'react-native';
import { FontAwesomeIcon} from '@fortawesome/react-native-fontawesome';
import { faCalendarDay, faUserCircle } from '@fortawesome/free-solid-svg-icons';
import { SafeAreaView } from 'react-native-safe-area-context';
import ProfileScreen from './ProfileScreen';
import CallendarScreen from './CallendarScreen';


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
            <ProfileNavIcon icon={faUserCircle} focused={focused} size={28}/>
            :
            <ProfileNavIcon icon={faCalendarDay} focused={focused} size={28}/>          
        })}>
        <Tab.Screen name={'Profil'} component={ProfileScreen}  />
        <Tab.Screen name={'Kalendarz'} component={CallendarScreen} />
    </Tab.Navigator>
  );
};

const ProfileNavIcon = styled(FontAwesomeIcon)`
  color: ${p => p.focused ? '#64b976' : 'grey'};
  opacity: ${p => p.focused ? 1.0 : 0.8};
`;

export default TabNavigator;